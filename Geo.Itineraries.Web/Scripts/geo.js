$('input[type="checkbox"].style3').checkbox({
    buttonStyle: 'btn-danger',
    buttonStyleChecked: 'btn-success',
    checkedClass: 'icon-check',
    uncheckedClass: 'icon-check-empty'
});

$('#radiusSlider').slider();

var nowTemp = new Date();
var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);

var checkin = $('#startDate').datepicker({
    onRender: function (date) {
        return date.valueOf() < now.valueOf() ? 'disabled' : '';
    }
}).on('changeDate', function (ev) {
    if (ev.date.valueOf() > checkout.date.valueOf()) {
        var newDate = new Date(ev.date)
        newDate.setDate(newDate.getDate() + 1);
        checkout.setValue(newDate);
    }
    checkin.hide();
    $('#endDAte')[0].focus();
}).data('datepicker');
var checkout = $('#endDate').datepicker({
    onRender: function (date) {
        return date.valueOf() <= checkin.date.valueOf() ? 'disabled' : '';
    }
}).on('changeDate', function (ev) {
    checkout.hide();
}).data('datepicker');