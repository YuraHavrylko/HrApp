$(document).ready(function() {
    $("#add-role").click(function() {
        $.ajax({
            url: "/Admin/CreateRole",
            method: "GET",
            dataType: "html",
            success: function(result) {
                $("#modal-default-content").html(result);
                $("#modal-default").modal('show');
            }
        });
    });

    $(".edit-role").click(function () {
        
        $.ajax({
            url: "/Admin/EditRole",
            data: { id: this.value },
            method: "GET",
            dataType: "html",
            success: function (result) {
                $("#modal-default-content").html(result);
                $("#modal-default").modal('show');
            }
        });
    });

    $(".edit-claims").click(function () {

        $.ajax({
            url: "/Admin/EditClaim",
            data: { id: this.value },
            method: "GET",
            dataType: "html",
            success: function (result) {
                $("#modal-default-content").html(result);
                $("#modal-default").modal('show');
            }
        });
    });

    $(".delete-role").click(function () {

        $.ajax({
            url: "/Admin/DeleteRole",
            data: { id: this.value },
            method: "GET",
            success: function (result) {
                location.reload();
            }
        });
    });

    $(".edit-user-role").click(function () {

        $.ajax({
            url: "/Admin/EditUserRole",
            data: { id: this.value },
            method: "GET",
            dataType: "html",
            success: function (result) {
                $("#modal-default-content").html(result);
                $("#modal-default").modal('show');
            }
        });
    });

    $(".edit-user").click(function () {

        $.ajax({
            url: "/Admin/EditUser",
            data: { id: this.value },
            method: "GET",
            dataType: "html",
            success: function (result) {
                $("#modal-default-content").html(result);
                $("#modal-default").modal('show');
            }
        });
    });

    $(".delete-user").click(function () {

        $.ajax({
            url: "/Admin/DeleteUser",
            data: { id: this.value },
            method: "GET",
            success: function (result) {
                location.reload();
            }
        });
    });
});

$(function () {
    var table = $('#roles').DataTable({
        lengthChange: true,
        buttons: [
            {
                extend: 'copy',
                exportOptions: {
                    columns: [0, 1]
                }
            },
            {
                extend: 'excel',
                exportOptions: {
                    columns: [0, 1]
                }
            },
            {
                extend: 'pdf',
                exportOptions: {
                    columns: [0, 1]
                }
            },
            {
                extend: 'print',
                exportOptions: {
                    columns: [0, 1]
                }
            }
        ]
    });
    table.buttons().container()
        .appendTo('#roles_wrapper .row:eq(0)');

    var userTable = $('#user-roles').DataTable({
        lengthChange: true,
        buttons: [
            {
                extend: 'copy',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                }
            },
            {
                extend: 'excel',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                }
            },
            {
                extend: 'pdf',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                }
            },
            {
                extend: 'print',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                }
            }
        ]
    });
    userTable.buttons().container()
        .appendTo('#user-roles_wrapper .row:eq(0)');

    var userTable = $('#users').DataTable({
        lengthChange: true,
        buttons: [
            {
                extend: 'copy',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                }
            },
            {
                extend: 'excel',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                }
            },
            {
                extend: 'pdf',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                }
            },
            {
                extend: 'print',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                }
            }
        ]
    });
    userTable.buttons().container()
        .appendTo('#users_wrapper .row:eq(0)');
})