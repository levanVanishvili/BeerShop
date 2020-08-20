var dataTable;

$(document).ready(function(){
    loadDataTable();
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/User/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "company.name", "width": "15%" },
            { "data": "role", "width": "15%" },
            //{
            //    "data": "id",
            //    "render": function (data) {
            //        return `
            //               <div class="text-center">
            //               <a href="/Admin/User/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
            //               <i class="fas fa-edit"></i>
            //               </a>
            //               <a onclick=Delete("/Admin/User/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
            //               <i class="fas fa-trash-alt"></i>
            //               </a>
            //               </div>   
            //               `;
            //    }, "width": "40%"
            //}

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