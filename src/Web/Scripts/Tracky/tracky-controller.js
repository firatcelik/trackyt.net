﻿$(document).ready(function () {
    var userId = $('#userId').val();
    var api = $('#api').val();


    // Tracky control initialization

    function loadData(callback) {
        $.post(api + '/GetAllTasks/' + userId, null, callback, 'json');
    }

    function submitData(data, callback) {
        $.postJson(api + '/Submit/' + userId, data, callback);
    }

    function deleteData(data, callback) {
        $.postJson(api + '/Delete/' + userId, data, callback);
    }

    var tracky = create_tracky(
        $('#tasks'),
        $('#task-description'),
        $('#add-task'),
        $('#submit'),
        loadData,
        submitData,
        deleteData
    );

    // Start All / Stop All initialization

    $('#start-all').click(startAll);
    $('#stop-all').click(stopAll);

    function startAll() {
        tracky.startAll();
    }

    function stopAll() {
        tracky.stopAll();
    }

    // Account details window initialization

    var detailsShown = false;
    $('#account-details').hide();
    $('#show-account-details').click(showAccountDetails);

    function showAccountDetails() {
        if (!detailsShown) {
            detailsShown = true;
            $('#account-details').slideDown('fast');
        } else {
            detailsShown = false;
            $('#account-details').slideUp('fast');
        }
    }

    // Window close

    $(window).unload(windowUnload);

    function windowUnload() {
        // silently submit all tasks
        tracky.submit();
    }

}
);
