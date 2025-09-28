var dataTable;
var element;
$(document).ready(function () {
    loadDataTable();
    $('#EditModal').on('show.bs.modal', function (e) {
        var podaci = dataTable.row($(e.relatedTarget).closest('tr')).data();
        $('#prodid').val(podaci.id);
        $('#Naziv1').val(podaci.naziv);
        $('#Opis1').val(podaci.opis);
        $('#Cena1').val(podaci.cena);
       
    })
});

function loadDataTable() {
    dataTable = $('#myTable').DataTable({
        "ajax": {
            "url": "/Usluga/GetAll",
            "dataSrc": "",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "naziv", "width": "5%" },
            { "data": "opis", "width": "5%" },
            { "data": "cena", "width": "5%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div style="display:inline-block">
                                <button class="btn btn-warning" onclick="izmeni(${data})" data-bs-toggle="modal" data-bs-target="#EditModal">Edit</button>
                                <button class="btn btn-danger" onclick="postaviId(${data})" data-bs-toggle="modal" data-bs-target="#DeleteModal">Delete</button>
                            </div>
                                   `;
                }, "width": "5%"
            }
        ]
    });
}
function postaviId(id) {
    $('#deleteId').val(id);
}

function izmeni(prodid) {
    $.ajax({
        type: "GET",
        url: "/Usluga/GetOne/",
        data: { id: prodid },
        success: function (item) {
            element = item;

            $('#EditModal').modal('show');
        }
    })

}

$('.btnCancel').click(function () {
    window.location.href = "/CMS/Index";
})