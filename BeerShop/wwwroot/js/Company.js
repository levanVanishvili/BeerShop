﻿var dataTable;

$(document).ready(function(){
    loadDataTable();
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Company/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "streetAddress", "width": "15%" },
            { "data": "city", "width": "10%" },
            { "data": "state", "width": "10%" },
            { "data": "phoneNumber", "width": "15%" },
            {
                "data": "IsAuthorizedCompany",
                "render": function (data) {
                    if (data) {
                        return `<input type="chechbox" disabled checked/>`
                    } else {
                        return `<input type="chechbox" disabled/>`
                    }
                },
                "width": "10%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                           <div class="text-center">
                           <a href="/Admin/Company/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                           <i class="fas fa-edit"></i>
                           </a>
                           <a onclick=Delete("/Admin/Company/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                           <i class="fas fa-trash-alt"></i>
                           </a>
                           </div>   
                           `;
                }, "width": "25%"
            }

        ]
    });
}

function Delete(url) {

    swal({
        title: "Are You Sure You Want To Delete?",
        text: "Will You Not Be Able To Restore The Data!",
        icon: "Warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}