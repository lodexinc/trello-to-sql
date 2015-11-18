var _token;
var _dbObj;

$(document).ready(function () {

    $.get('scripts/createtrello.txt', function (result) {
        $('#txtScript').text(result);
    });

});

function nextStep() {

    $.get('checkdb.ashx?' + (+new Date()), function (result) {
        $('#connString').val(result.ConnString);
        $('#btn6').attr('disabled', null);
    });

    // Proceed
    $('#step0').hide();
    $('#step1').show();

}

function backToStart() {
    $('#step1').hide();
    $('#step0').show();
}

function createDatabase() {

    $('#btn6').attr('disabled', 'disabled');
    $('#step1').find('.output').css({ 'color': '' }).html('Verifying database existence...');

    $.get('checkdb.ashx?action=checkdb&conn=' + encodeURIComponent($('#connString').val()) + '&nocache=' + (+new Date()), function (result) {

        _dbObj = result;

        if (result.Success) {

            $('#step1').find('.output').css({ 'color': '#4caf50' }).html('<strong>Status:</strong> Database located at current server. Proceeding...');

            setTimeout(function () {

                // Proceed
                $('#step1').hide();
                $('#step2').show();

            }, 3000);

        }
        else {

            $('#step1').find('.output').css({ 'color': '#f44336' }).html('Could not locate Trello database!');
            $('#btn6').attr('disabled', null);

        }

    });

}

function auth() {

    Trello.authorize({
        type: "popup",
        name: "Trello Reporting",
        scope: { read: true, write: false },
        expiration: "never",
        success: function () {
            _token = Trello.token();
            $('#step2 .output').css({ 'color': '#4caf50' }).html('<strong>Status:</strong> All set, we have access to your boards!');
            $('#btn1').attr('disabled', 'disabled');
            $('#btn2').attr('disabled', null);
        },
        error: function () {
            $('#step2 .output').html('ERROR: Please try again.');
        }
    });

};

var _timer;

function start() {

    $('#btn2').attr('disabled', 'disabled');
    $('#step2 .output').css({ 'color': '' }).html('Downloading your entire Trello board...');

    _timer = setTimeout(function () {
        $('#step2 .output').html('This might be a while, go make coffee...');
        _timer = setTimeout(function () {
            $('#step2 .output').html('Still busy, sometimes it can take like 10 minutes...');
            _timer = setTimeout(function () {
                $('#step2 .output').html('Downloading, please wait...');
            }, 10000);
        }, 10000);
    }, 10000);

    // Begin process
    $.get('worker.ashx?token=' + Trello.token(), function (result) {

        clearTimeout(_timer);
        $('#step2 .output').html(result);
        $('#btn2, #btn3, #btn4').attr('disabled', null);
        $('#btn2').html('Re-download data');

    });

};

function importData() {

    $('#step2 .output').html('Importing your data...');

    _timer = setTimeout(function () {
        $('#step2 .output').html('Shouldn\'t take much longer...');
        _timer = setTimeout(function () {
            $('#step2 .output').html('Importing, please wait...');
        }, 10000);
    }, 10000);

    // Begin process
    $.get('import.ashx?token=' + Trello.token(), function (result) {

        clearTimeout(_timer);
        $('#step2 .output').html(result);
        $('#btn2, #btn3').attr('disabled', 'disabled');
        $('#btn4').html('Re-import data');
        $('#btn5').attr('disabled', null);

    });

}

function excel() {

    window.open('excel.ashx');

}