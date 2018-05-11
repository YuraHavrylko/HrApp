$(document).ready(function() {
    $("#forgot-pass").click(function () {
        $.ajax({
            url: "/Account/ForgotPassword",
            method: "GET",
            dataType: "html",
            success: function (result) {
                $("#modal-default-content").html(result);
                $("#modal-default").modal('show');
            }
        });
    });
    $(".show-modal").click(function() {
        $("#modal-default").modal('show');
    });
});