// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function() {

    var webAPIUrlBase = "http://localhost:19422/api/";

    // Boostrap components init
    $('#add-event').on('shown.bs.modal', function() {
        $('#myInput').trigger('focus')
    });

    $('#add-event').on('click', function() {
        let modal = $('#event-modal-body');

        if ($(modal).data('event-action') === 'edit')
            resetModalValues();

        $(modal).data('event-action', 'add');
        
    });

    $('.datetimepicker').datetimepicker({
        format: 'yyyy-mm-dd hh:ii',
    });

    $(function () {
        $('[data-toggle="tooltip"]').tooltip()
    })
    // ---------------------------------

    // bootstrap input file name change
    $('input[type="file"]').change(function(e) {
        var fileName = e.target.files[0].name;
        $(this).parent().find('.custom-file-label').html(fileName); // showing file name

        $(this).data('need-to-save', 'true'); // data attribute for additional checking if it is add or edit event

        // setting image in img tag for preview
        let photoPreview = $(this).parent().parent().find('.preview-photo');
        readURL(e.target, photoPreview);
    });

    const toBase64 = file => new Promise((resolve, reject) => {
        if (file && file !== 'undefined') {
            const reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = () => resolve(reader.result.split(',')[1]);
            reader.onerror = error => reject(error);
        }
        else {
            return '';
        }
    });

    function readURL(input, previewElement) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $(previewElement).attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]); // convert to base64 string
        }
    }

    function updateEventsTable(row, eventId) {
        let eventsTable = $('.events-table');

        let rowHTML = '<tr data-event-id="' + eventId + '">' +
            '<th scope="row">' + (parseInt(getLastTableNumber()) + 1) + '</th>' +
                '<td><img src="' + 'data:image/jpeg;base64,' + row.EventImages[0].ImageBase64 + '" height="100" width="200" /></td>' +
                '<td>' + row.Title + '</td >' +
                '<td>' + row.City + ' ' + row.Street + ', ' + row.Country + '</td >' +
                '<td>' + row.StartDate + '</td >' +
                '<td>' + row.FinishDate + '</td >' +
                '<td>' +
                '<div class="icon-containers-row">' +
                    '<span class="icon-container">' +
                        '<img class="action-icon edit" src="../img/edit-outline.svg" alt="Alternate Text" height="32" width="24" />' +
                    '</span>' +
                    '<span class="icon-container">' +
                        '<img class="action-icon delete" src="../img/bin-outline.svg" alt="Alternate Text" height="32" width="24" />' +
                    '</span>' +
                '</div>' +
                '</td>' +
            '</tr>';

        eventsTable.append(rowHTML);
    }

    function getLastTableNumber() {
        let eventsTable = $('.events-table tr');
        let lastRow = $(eventsTable).last();

        return lastRow.find('th').html();
    }

    $('#action-save-event').on('click', function() {
        let modal = $('#event-modal-body');

        if ($(modal).data('event-action') === 'add')
            addEvent();
        else {
            updateEvent();
        }

 
        async function updateEvent() {
            let eventTitle = $('#event-title').val();
            let eventShortDesc = $('#event-short-description').val();
            let eventLongDesc = $('#event-long-description').val();
            let eventCountry = $('#event-country').val();
            let eventCity = $('#event-city').val();
            let eventDistrict = $('#event-district').val();
            let eventStreet = $('#event-street').val();
            let eventStartDate = $('#event-start-date').val();
            let eventFinishDate = $('#event-finish-date').val();
            let eventLat = $('#event-latitude').val();
            let eventLng = $('#event-longitude').val();
            let eventDuration = $('#event-length-in-days').val();
            let eventDistributorURL = $('#event-tickets-url').val();

            let photoArray = [];
            let imageObject = {
                ImageId: 0,
                ImageBase64: ""
            };

            if (document.getElementById('inputGroupFile01').files.length != 0) {
                let eventPhoto1 = await toBase64(document.getElementById('inputGroupFile01').files[0]);

                let imageObject = {
                    IsCover: 'true',
                    ImageId: 0,
                    ImageBase64: ""
                };
                imageObject.ImageId = $('.photo-1').data('image-id');
                imageObject.ImageBase64 = eventPhoto1;
                photoArray.push(imageObject);
            }
            if (document.getElementById('inputGroupFile02').files.length != 0) {
                let eventPhoto2 = await toBase64(document.getElementById('inputGroupFile02').files[0]);

                let imageObject1 = {
                    IsCover: 'false',
                    ImageId: 0,
                    ImageBase64: ""
                };
                imageObject1.ImageId = $('.photo-2').data('image-id');
                imageObject1.ImageBase64 = eventPhoto2;
                photoArray.push(imageObject1);
            }
            if (document.getElementById('inputGroupFile03').files.length != 0) {
                let eventPhoto3 = await toBase64(document.getElementById('inputGroupFile03').files[0]);

                let imageObject2 = {
                    IsCover: 'false',
                    ImageId: 0,
                    ImageBase64: ""
                };
                imageObject2.ImageId = $('.photo-3').data('image-id');
                imageObject2.ImageBase64 = eventPhoto3;
                photoArray.push(imageObject2);
            }
            if (document.getElementById('inputGroupFile04').files.length != 0) {
                let eventPhoto4 = await toBase64(document.getElementById('inputGroupFile04').files[0]);

                let imageObject3 = {
                    IsCover: 'false',
                    ImageId: 0,
                    ImageBase64: ""
                };
                imageObject3.ImageId = $('.photo-4').data('image-id');
                imageObject3.ImageBase64 = eventPhoto4;
                photoArray.push(imageObject3);
            }
            if (document.getElementById('inputGroupFile05').files.length != 0) {
                let eventPhoto5 = await toBase64(document.getElementById('inputGroupFile05').files[0]);

                let imageObject4 = {
                    IsCover: 'false',
                    ImageId: 0,
                    ImageBase64: ""
                };
                imageObject4.ImageId = $('.photo-5').data('image-id');
                imageObject4.ImageBase64 = eventPhoto5;
                photoArray.push(imageObject4);
            }

            var eventDTO = {
                'EventId': $(thisEventIdButton).data('event-id'),
                'Title': eventTitle,
                'ShortDescription': eventShortDesc,
                'LongDescription': eventLongDesc,
                'GoingPeopleCount': 0,
                'InterestedPeopleCount': 0,
                'StartDate': eventStartDate,
                'FinishDate': eventFinishDate,
                'DaysEventActive': eventDuration,
                'Country': eventCountry,
                'City': eventCity,
                'Street': eventStreet,
                'District': eventDistrict,
                'Lat': eventLat,
                'Lng': eventLng,
                'DistributorUrl': eventDistributorURL,
                'EventImages': photoArray
            }

            let url = webAPIUrlBase + 'event/update-event';
            let stringifiedData = JSON.stringify(eventDTO);

            $.ajax({
                url: url,
                data: stringifiedData,
                method: "POST",
                dataType: "json",
                contentType: "application/json",
                success: function (data) {
                    $('#exampleModalCenter').modal('hide');
                    showSuccessAlert('Success! Event saved succesfully.');
                },
                error: function (xhr, error) {
                    console.log('xhr', xhr);
                    console.log('error --- ', error);
                }
            });
        }

        async function addEvent() {
            let eventTitle = $('#event-title').val();
            let eventShortDesc = $('#event-short-description').val();
            let eventLongDesc = $('#event-long-description').val();
            let eventCountry = $('#event-country').val();
            let eventCity = $('#event-city').val();
            let eventDistrict = $('#event-district').val();
            let eventStreet = $('#event-street').val();
            let eventStartDate = $('#event-start-date').val();
            let eventFinishDate = $('#event-finish-date').val();
            let eventLat = $('#event-latitude').val();
            let eventLng = $('#event-longitude').val();
            let eventDuration = $('#event-length-in-days').val();
            let eventDistributorURL = $('#event-tickets-url').val();

            let photoArray = [];

            if (document.getElementById('inputGroupFile01').files.length != 0) {
                let eventPhoto1 = await toBase64(document.getElementById('inputGroupFile01').files[0]);

                let imageObject = {
                    IsCover: 'true',
                    ImageId: 0,
                    ImageBase64: ""
                };
                imageObject.ImageBase64 = eventPhoto1;
                photoArray.push(imageObject);
            }
            if (document.getElementById('inputGroupFile02').files.length != 0) {
                let eventPhoto2 = await toBase64(document.getElementById('inputGroupFile02').files[0]);

                let imageObject1 = {
                    IsCover: 'false',
                    ImageId: 0,
                    ImageBase64: ""
                };
                imageObject1.ImageBase64 = eventPhoto2;
                photoArray.push(imageObject1);
            }
            if (document.getElementById('inputGroupFile03').files.length != 0) {
                let eventPhoto3 = await toBase64(document.getElementById('inputGroupFile03').files[0]);

                let imageObject2 = {
                    IsCover: 'false',
                    ImageId: 0,
                    ImageBase64: ""
                };
                imageObject2.ImageBase64 = eventPhoto3;
                photoArray.push(imageObject2);
            }
            if (document.getElementById('inputGroupFile04').files.length != 0) {
                let eventPhoto4 = await toBase64(document.getElementById('inputGroupFile04').files[0]);

                let imageObject3 = {
                    IsCover: 'false',
                    ImageId: 0,
                    ImageBase64: ""
                };
                imageObject3.ImageBase64 = eventPhoto4;
                photoArray.push(imageObject3);
            }
            if (document.getElementById('inputGroupFile05').files.length != 0) {
                let eventPhoto5 = await toBase64(document.getElementById('inputGroupFile05').files[0]);

                let imageObject4 = {
                    IsCover: 'false',
                    ImageId: 0,
                    ImageBase64: ""
                };
                imageObject4.ImageBase64 = eventPhoto5;
                photoArray.push(imageObject4);
            }

            var eventDTO = {
                'EventId': 0,
                'Title': eventTitle,
                'ShortDescription': eventShortDesc,
                'LongDescription': eventLongDesc,
                'GoingPeopleCount': 0,
                'InterestedPeopleCount': 0,
                'StartDate': eventStartDate,
                'FinishDate': eventFinishDate,
                'DaysEventActive': eventDuration,
                'Country': eventCountry,
                'City': eventCity,
                'Street': eventStreet,
                'District': eventDistrict,
                'Lat': eventLat,
                'Lng': eventLng,
                'DistributorUrl': eventDistributorURL,
                'EventImages': photoArray
            }

            let url = webAPIUrlBase + 'event/add-event';
            let stringifiedData = JSON.stringify(eventDTO);

            $.ajax({
                url: url,
                data: stringifiedData,
                method: "POST",
                dataType: "json",
                contentType: "application/json",
                success: function (data) {
                    // data - eventId
                    $('#exampleModalCenter').modal('hide');
                    showSuccessAlert('Success! Event created successfully');
                    updateEventsTable(eventDTO, data);
                },
                error: function(xhr, error) {
                    console.log('xhr', xhr);
                    console.log('error --- ', error);
                }
            });
        }

        
    });

    var thisEventIdButton;
    $('.action-icon.delete').on('click', function() {
        thisEventIdButton = this;
    }).confirm({
        content: 'Are you sure want to delete event?',
        title: 'Delete',
        closeIcon: true,
        buttons: {
            yes: {
                text: 'YES', // text for button
                btnClass: 'btn-warning', // class for the button
                keys: ['enter', 'a'], // keyboard event for button
                action: function() {
                    deleteEvent(thisEventIdButton);
                }
            },
            no: {
                text: 'CANCEL', // text for button
                btnClass: 'btn-dark', // class for the button
                keys: ['esc'], // keyboard event for button
            }
        }
    });

    function deleteEvent(button) {
        let thisButton = button;

        let url = webAPIUrlBase + 'event/remove-event/' + $(thisButton).data('event-id');

        $.ajax({
            url: url,
            data: '',
            method: "POST",
            dataType: "json",
            contentType: "application/json",
            success: function(data) {
                $(thisButton).parent().parent().parent().parent().hide();
                showSuccessAlert('Success! Event removed.');
            },
            error: function(xhr, error) {
                console.log('xhr', xhr);
                console.log('error --- ', error);
            }
        });
    }

    $('.action-icon.edit').on('click', function() {
        let thisButton = this;
        thisEventIdButton = this;
        let modal = $('#event-modal-body');
        $(modal).data('event-action', 'edit');
        resetModalValues();
                
        let url = webAPIUrlBase + 'event/' + $(thisButton).data('event-id');

        $.ajax({
            url: url,
            method: "GET",
            dataType: "json",
            contentType: "application/json",
            success: function(data) {
                updateModalWithValues(data);
            },
            error: function(xhr, error) {
                console.log('xhr', xhr);
                console.log('error --- ', error);
            }
        });
    });


    function updateModalWithValues(event) {
        let address = event.Address; 
        let images = event.Images;
        let tickets = event.Tickets;

        $('#event-title').val(event.Title);
        $('#event-short-description').val(event.ShortDescription);
        $('#event-long-description').val(event.LongDescription);
        $('#event-country').val(address.Country);
        $('#event-city').val(address.City);
        $('#event-district').val(address.District);
        $('#event-street').val(address.Street1);
        $('#event-latitude').val(address.Lat);
        $('#event-longitude').val(address.Lng);


        // Date Formatting
        let startDate = new Date(event.StartDate);
        let finishDate = new Date(event.FinishDate);

        let startDateString = startDate.getFullYear() + '-' +
            prependZero(startDate.getMonth() + 1)
            + '-' +
            prependZero(startDate.getDate())
            + ' ' +
            prependZero(startDate.getHours()) + ':' +
            prependZero(startDate.getMinutes());

        let finishDateString = finishDate.getFullYear() + '-' +
            prependZero(finishDate.getMonth() + 1)
            + '-' +
            prependZero(finishDate.getDate())
            + ' ' +
            prependZero(finishDate.getHours()) + ':' +
            prependZero(finishDate.getMinutes());

        $('#event-start-date').val(startDateString);
        $('#event-finish-date').val(finishDateString);


        $('#event-length-in-days').val(event.DaysEventActive);

        if(tickets.length > 0)
            $('#event-tickets-url').val(tickets[0].DistributorUrl);

        // images
        for (let i = 0; i < images.length; i++) {
            let baseIdentificator = '.photo-';
            let elementIdentificator = baseIdentificator + (i + 1).toString();
            $(elementIdentificator).html(images[i].Caption)
            $(elementIdentificator).first().data('image-id', images[i].ImageId);

            let photoPreview = $(elementIdentificator).parent().parent().find('.preview-photo');
            $(photoPreview).attr('src', images[i].PathOnServer);
        }
    }

    function resetModalValues() {
        $('#event-title').val('');
        $('#event-short-description').val('');
        $('#event-long-description').val('');
        $('#event-country').val('');
        $('#event-city').val('');
        $('#event-district').val('');
        $('#event-street').val('');
        $('#event-latitude').val('');
        $('#event-longitude').val('');
        $('#event-start-date').val('');
        $('#event-finish-date').val('');
        $('#event-length-in-days').val('');
        $('#event-tickets-url').val('');

        $('.photo-1').html('Choose file');
        let photoPreview = $('.photo-1').parent().parent().find('.preview-photo');
        $(photoPreview).attr('src', '../img/upload-photo.svg');


        $('.photo-2').html('Choose file');
        photoPreview = $('.photo-2').parent().parent().find('.preview-photo');
        $(photoPreview).attr('src', '../img/upload-photo.svg');


        $('.photo-3').html('Choose file');
        photoPreview = $('.photo-3').parent().parent().find('.preview-photo');
        $(photoPreview).attr('src', '../img/upload-photo.svg');


        $('.photo-4').html('Choose file');
        photoPreview = $('.photo-4').parent().parent().find('.preview-photo');
        $(photoPreview).attr('src', '../img/upload-photo.svg');


        $('.photo-5').html('Choose file');   
        photoPreview = $('.photo-5').parent().parent().find('.preview-photo');
        $(photoPreview).attr('src', '../img/upload-photo.svg');
    }

    function prependZero(value) {
        if (value < 10) {
            return ('0' + value);
        }
        else {
            return value;
        }
    }

    function showSuccessAlert(message) {
        $("#alert-box").html("<div class='alert alert-success alert-dismissable'>" + message +
            "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button > </div> ");
    }
    function showErrorAlert(message) {
        $("#alert-box").html("<div class='alert alert-danger alert-dismissable'>" + message +
            "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button > </div> ");
    }

});
