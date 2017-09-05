
$(function () {
    $("[data-datetimepicker]").datetimepicker({
        timepicker: false,
        format: 'Y-m-d',
        maxDate: '+1970/01/01'
    });
});
