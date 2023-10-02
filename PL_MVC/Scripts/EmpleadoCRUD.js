$(document).ready(function () {

    GetAll();

});


//postback 

function GetAll() {
    //peticion AJAX
    function loadData() {
        $.ajax({
            url: "/Empleado1/Get",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                var html = '';
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td>' + item.IdEmpleado + '</td>';
                    html += '<td>' + item.NumeroEmpleado + '</td>';
                    html += '<td>' + item.RFC + '</td>';
                    html += '<td>' + item.Nombre + '</td>';
                    html += '<td>' + item.ApellidoPaterno + '</td>';
                    html += '<td><a href="#" onclick="return getbyID(' + item.EmployeeID + ')">Edit</a> | <a href="#" onclick="Delele(' + item.EmployeeID + ')">Delete</a></td>';
                    html += '</tr>';
                });
                $('.tbody').html(html);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}