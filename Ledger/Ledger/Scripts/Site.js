
$(function () {
    $("[data-datetimepicker='y']").datetimepicker({
        timepicker: false,
        format: 'Y-m-d',
        maxDate: '+1970/01/01'
    });

    $("[data-numeric='y']").spinner();

});
