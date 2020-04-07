using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventLookup.Domain.Services;
using EventLookup.Domain.Models;
using EventLookup.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;



using EventLookup.Domain.DTOs.User;
using EventLookup.Shared;
using System.Security.Cryptography;
using System.IO;
using System.Drawing;
using Microsoft.AspNetCore.Hosting;

namespace EventLookup.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IConfiguration _conf;
        private readonly IWebHostEnvironment _hostingEnvironment;

        private string scheme;
        private string baseUrl;
        private string sharedVirtualPath;
        Consts consts;

        public UserService(IUserRepository userRepository, IMapper mapper, IHttpContextAccessor cont, IConfiguration conf, IWebHostEnvironment environment)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContext = cont;
            _conf = conf;

            scheme = _httpContext.HttpContext.Request.Scheme.ToString(); // http : https
            baseUrl = _httpContext.HttpContext.Request.Host.Value; // localhost:<port>
            sharedVirtualPath = _conf.GetValue<string>("SharedImagesPath"); // app-images
            consts = Consts.Instance;
            _hostingEnvironment = environment;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersList()
        {
            var users = await _userRepository.GetUsersList();
            IEnumerable<UserDTO> mappedUsers = _mapper.Map<IEnumerable<UserDTO>>(users);

            return mappedUsers;
        }

        public async Task<UserDTO> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            UserDTO mappedUser = _mapper.Map<UserDTO>(user);
            foreach (var mappedUserEvent in mappedUser.UserEvents) {
                mappedUserEvent.User = null;
                int eventId = mappedUserEvent.EventId;
                mappedUserEvent.Event = await _userRepository.GetUserEvent(eventId);

                foreach (var eventImage in mappedUserEvent.Event.Images)
                {
                    if (eventImage.IsCover)
                    {
                        var imageInfo = Path.GetFileName(eventImage.PathOnServer);
                        eventImage.PathOnServer = $"{scheme}://{baseUrl}/{sharedVirtualPath}/{imageInfo}";
                    }
                    else
                    {
                        mappedUserEvent.Event.Images.Remove(eventImage);
                    }
                }

            }

            var userImageInfo = Path.GetFileName(mappedUser.ImagePath);
            mappedUser.ImagePath = $"{scheme}://{baseUrl}/{sharedVirtualPath}/{userImageInfo}";

            return mappedUser;
        }

        public async Task<bool> UpdateUser(User user, string token)
        {
            if (CheckIfTokenMatches(user.Token, token))
            {
                var result = await _userRepository.UpdateUser(user, token);
                return result;
            }

            return false;
        }

        public async Task<bool> RemoveUserEvent(int userId, int eventId)
        {
            return await _userRepository.RemoveUserEvent(userId, eventId);
        }

        public async Task<bool> MarkUserEvent(UserEvent userEvent)
        {
            return await _userRepository.MarkUserEvent(userEvent);
        }
        public async Task<bool> UploadUserImage(User user, string token)
        {
            if (CheckIfTokenMatches(user.Token, token))
            {
                string imagePath = SaveImageToSharedDirectory(user.ImagePath);

                if (imagePath != "")
                {
                    user.ImagePath = imagePath;
                    return await _userRepository.UploadUserImage(user, token);
                }
            }

            return false;
        }


        public async Task<AuthenticationUser> UserLoginWithToken(string token)
        {
            AuthenticationUser returnableUser = new AuthenticationUser();

            var handler = new JwtSecurityTokenHandler();
            var userToken = handler.ReadJwtToken(token);

            string userEmail = userToken.Claims.First(c => c.Type == "email").Value;

            var userFromDb = await _userRepository.FindUserByEmail(new User { Email = userEmail });
            if (userFromDb != null)
            {
                DateTime expirationDate = userToken.ValidTo;
                int datesComparison = DateTime.Compare(DateTime.Now, expirationDate);
                if (datesComparison > 0)
                {
                    returnableUser.Message = consts.getTokenExpiredTuple();
                    return returnableUser;
                }

                returnableUser.Id = userFromDb.UserId;
                return returnableUser;
            }
            else
            {
                returnableUser.Message = consts.getNoUserTuple();
            }

            return null;
        }

        public async Task<AuthenticationUser> UserLogin(User user)
        {
            AuthenticationUser returnableUser = new AuthenticationUser();
       
            User currentUser = await _userRepository.FindUserByEmail(user);
            if(currentUser != null)
            {
                byte[] passwordInputBytes = System.Text.Encoding.ASCII.GetBytes(user.Password);
                string passwordInputHash;
                using (SHA256Managed manager = new SHA256Managed())
                {
                    passwordInputBytes = manager.ComputeHash(passwordInputBytes);
                    passwordInputHash = System.Text.Encoding.ASCII.GetString(passwordInputBytes);
                }

                if (passwordInputHash.Equals(currentUser.Password))
                {
                    string userToken = GenerateToken(currentUser.Email);
                    currentUser.Token = userToken;
                    bool isSuccessful = await _userRepository.SaveUser(currentUser);
                    if (!isSuccessful) {
                        returnableUser.Message = consts.getProblemsWithServerTuple();
                        return returnableUser;
                    }

                    returnableUser.Id = currentUser.UserId;
                    returnableUser.Token = userToken;
                    return returnableUser;
                }
                else
                {
                    returnableUser.Message = consts.getInvalidPasswordTuple();
                }
            }

            returnableUser.Message = consts.getNoUserTuple();
            return returnableUser;
        }

        public async Task<AuthenticationUser> UserRegister(User user)
        {
            AuthenticationUser returnableUser = new AuthenticationUser();

            User currentUser = await _userRepository.FindUserByEmail(user);
            if (currentUser == null)
            {
                byte[] passwordInputBytes = System.Text.Encoding.ASCII.GetBytes(user.Password);
                passwordInputBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordInputBytes);
                string passwordInputHash = System.Text.Encoding.ASCII.GetString(passwordInputBytes);

                string userToken = GenerateToken(user.Email);

                currentUser = new User();
                currentUser.Email = user.Email;
                currentUser.Password = passwordInputHash;
                currentUser.DisplayName = user.DisplayName;
                currentUser.Token = userToken;
                
                bool isSuccessful = await _userRepository.SaveUser(currentUser);
                if (!isSuccessful)
                {
                    returnableUser.Message = consts.getProblemsWithServerTuple();
                    return returnableUser;
                }

                returnableUser.Id = currentUser.UserId;
                returnableUser.Token = userToken;
                return returnableUser;
            }

            returnableUser.Message = consts.getUserExistsTuple();
            return returnableUser;
        }

        // To generate Secret for appsettings.json
        // var hmac = new HMACSHA256();
        // var key = Convert.ToBase64String(hmac.Key); 
        private string GenerateToken(string email)
        {

            var symmetricKey = Convert.FromBase64String(_conf["Jwt:Secret"]);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email)
                }),

                Expires = now.AddDays(365),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        private bool CheckIfTokenMatches(string token1, string token2)
        {
            if (token1.Equals(token2))
                return true;

            return false;
        }

        private string SaveImageToSharedDirectory(string imageBase64)
        {
            string imageName = Guid.NewGuid().ToString() + ".png";
            string saveImagePath = _hostingEnvironment.ContentRootPath + "/Shared/Files/Images/" + imageName;
            byte[] bytes = Convert.FromBase64String(imageBase64);

            System.Drawing.Image bitmapImage;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                bitmapImage = System.Drawing.Image.FromStream(ms);
                bitmapImage.Save(saveImagePath);

                if (File.Exists(_hostingEnvironment.ContentRootPath + "/Shared/Files/Images/" + imageName))
                    return imageName;
                return "";
            }
        }

    }
}
