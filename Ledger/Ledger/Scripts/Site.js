
$(function () {
    $("[data-datetimepicker='y']").datetimepicker({
        timepicker: false,
        format: 'Y/m/d',
        maxDate: '+1970/01/01'
    });

    $("[data-numeric='y']").spinner();

});


$.validator.addMethod("beforetoday", function (value, element) {
    if (value == false) {
        return true;
    }
    var now = new Date();
    var today = now.getFullYear() + "/" + (now.getMonth() + 1) + "/" + now.getDate();
    if (value <= today) {
        return true;
    }
    return false;
});
$.validator.unobtrusive.adapters.addBool("beforetoday");

