$(function () {
    $('.agregar-material-mensual').on('click', function () {


        if ($('#demo-cs-multiselect option:selected').val() == '') {

            return;
        }
        const opts = {
            id: $('#demo-cs-multiselect option:selected').val(),
            nombre: $('#demo-cs-multiselect option:selected').text(),
            
        }
    });
});


