//$(function () {
//    $("#charters").dataTable({
//        serverSide: true,
//        ajax: "/charters/PageData",
//        columns: [
//            {
//                name: 'id',
//                data: 'id',
//                title: "Id",
//                sortable: false,
//                searchable: false
//            },
//            {
//                name: 'name',
//                data: "name",
//                title: "Name",
//                sortable: false,
//                searchable: false
//            },
//            {
//                name: 'number',
//                data: "number",
//                title: "Number",
//                sortable: false,
//                searchable: false
//            },
//            {
//                name: 'city',
//                data: "city",
//                title: "City",
//                sortable: false,
//                searchable: false
//            },
//            {
//                name: 'bodyType',
//                data: "bodyType",
//                title: "Body",
//                sortable: false,
//                searchable: false
//            },
//            {
//                name: 'lodgeType',
//                data: "lodgeType",
//                title: "Lodge",
//                sortable: false,
//                searchable: false
//            },
//            {
//                data: "Id", render: function(data) {
//                    return "<a class='btn btn-default btn-sm' onclick=PopupForm('@Url.Action("AddOrEdit","Charters")/" + data + "')><i class='fa fa-pencil'></i> Edit</a><a class='btn btn-danger btn-sm' style='margin-left:5px' onclick=Delete("+data+")><i class='fa fa-trash'></i> Delete</a>";
//                }
//            }
//        ]
//    });
//});  