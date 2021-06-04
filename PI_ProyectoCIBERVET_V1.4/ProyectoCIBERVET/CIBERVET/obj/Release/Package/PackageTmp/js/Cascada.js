$(document).ready(function () {
    console.log("entrandoi")
    $("#especieid").change(function () {
        $("#razaid").empty();
        $.ajax({
            type: 'POST',
            url: Url,
            dataType: 'json',
            data: { idespecie: $("#especieid").val() },
            success: function (razas) {
                $.each(razas, function (i, raza) {
                    $("#razaid").append('<option value="'
                        + raza.idraza + '">'
                        + raza.raza + '</option>');
                });
            },
            error: function (ex) {
                console.log("error");
                alert('Fallo la conexion al traer las razas.' + ex)
            }
        });
        return false;
    })
});