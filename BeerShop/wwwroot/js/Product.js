var dataTable;

$(document).ready(function(){
    loadDataTable();
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "Style.Name", "width": "20%" },
            { "data": "ContainerType.Name", "width": "10%" },
            { "data": "ContainerSize.Size", "width": "10%" },
            { "data": "ABV", "width": "5%" },
            { "data": "Price", "width": "8%" },
            { "data": "Brewery", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                           <div class="text-center">
                           <a href="/Admin/Product/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                           <i class="fas fa-edit"></i>
                           </a>
                           <a onclick=Delete("/Admin/Product/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                           <i class="fas fa-trash-alt"></i>
                           </a>
                           </div>   
                           `;
                }, "width": "40%"
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