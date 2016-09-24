$(function () {
    init()
});

function init() {
    $(".frm-submit-fobinacci").click(function () {
        getFibonacci($('.frm-number').val());
    });
    $(".frm-submit-xml").click(function () {
        postXmlToService($('.frm-xml-input').val());
    });
};

function getFibonacci(number) {
    if (!/^-?[0-9]+$/.test(number)) {
        $('.container-fobinacci-ouput').text("Invalid number! Only input integer (pattern /^-?[0-9]+$/)");
        return;
    }

    $.getJSON('api/Fibonacci/' + number)
    .done(function (data) {
        $('.container-fobinacci-ouput').text("Fibonacci of " + number + " is " + data);
    })
    .fail(function (xhr, textStatus, err) {
        $('.container-fobinacci-ouput').text("error: " + err);
    });
};

function postXmlToService(xml) {
    
    $.post(
        'api/ToJson/',
        {'':xml},
        function (data, status) {
            var innerHtml = data
                .replace(/\r\n/g, "<br/>")
                .replace(/\s/g, "&nbsp;");
            $('.container-parser-ouput').html(innerHtml);
        }, 'json'
        );
};

