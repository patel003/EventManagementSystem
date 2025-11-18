var UserMasterdatatable = function () {

    // demo initializer
    return {
        CashierJSONArray: [],

        init: function () {
            this.fetchcashierData();
        },

        fetchcashierData: async function () {

            try {
                const response = await fetch('/UserMaaster/GETALL');
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }

                const CashierResponseData = await response.json();

                console.log(CashierResponseData);

                this.CashierJSONArray = CashierResponseData.data;

                // Initialize the datatable
                this.initializeDatatable();
            } catch (error) {
                console.error('Fetch error:', error);
            }
        },

        initializeDatatable: function () {
            var datatable = $('#UserMasterDatatableID').KTDatatable({
                // datasource definition
                data: {
                    type: 'local',
                    source: this.CashierJSONArray,
                    pageSize: 10,
                },

                // layout definition
                layout: {
                    scroll: false, // enable/disable datatable scroll both horizontal and vertical when needed.
                    // height: 450, // datatable's body's fixed height
                    footer: false, // display/hide footer
                },

                // column sorting
                sortable: true,

                pagination: true,

                search: {
                    input: $('#kt_datatable_search_query'),
                    key: 'generalSearch'
                },

                // columns definition
                columns: [{
                    field: 'id',
                    title: 'id',
                    sortable: false,
                    visible: false,
                    width: 20,
                    type: 'number',
                    selector: {
                        class: ''
                    },
                    textAlign: 'center',
                }, {
                    field: 'SerialNo',
                    title: 'S.No.',
                    width: 50,
                    template: function (row, index) {
                        return ++index;
                    }
                }, {
                    field: 'fulL_NAME',
                    title: 'fulL_NAME',
                }, {
                    field: 'email',
                    title: 'email',
                }, {
                    field: 'phonE_NO',
                    title: 'phonE_NO',
                }, {
                    field: 'address',
                    title: 'address',
                }, {
                    field: 'rolE_NAME',
                    title: 'rolE_NAME',
                }, {
                    field: 'pass',
                    title: 'pass',
                }, {
                    field: 'isactive',
                    title: 'isactive',
                }, {
                    field: 'createD_DATE',
                    title: 'createD_DATE',
                }, {
                    field: 'rolE_ID',
                    title: 'rolE_ID',




                }, {
                    field: 'action',
                    title: 'Actions',
                    sortable: false,
                    width: 125,
                    overflow: 'visible',
                    autoHide: false,
                    template: function (row) {
                        return '\
							<a href="javascript:;" class="btn btn-sm btn-clean btn-icon mr-2" title="Edit details" data-id="'+ row.id + '" onclick = "EditformofUM(this)" >\
	                            <span class="svg-icon svg-icon-md">\
	                                <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">\
	                                    <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">\
	                                        <rect x="0" y="0" width="24" height="24"/>\
	                                        <path d="M8,17.9148182 L8,5.96685884 C8,5.56391781 8.16211443,5.17792052 8.44982609,4.89581508 L10.965708,2.42895648 C11.5426798,1.86322723 12.4640974,1.85620921 13.0496196,2.41308426 L15.5337377,4.77566479 C15.8314604,5.0588212 16,5.45170806 16,5.86258077 L16,17.9148182 C16,18.7432453 15.3284271,19.4148182 14.5,19.4148182 L9.5,19.4148182 C8.67157288,19.4148182 8,18.7432453 8,17.9148182 Z" fill="#000000" fill-rule="nonzero"\ transform="translate(12.000000, 10.707409) rotate(-135.000000) translate(-12.000000, -10.707409) "/>\
	                                        <rect fill="#000000" opacity="0.3" x="5" y="20" width="15" height="2" rx="1"/>\
	                                    </g>\
	                                </svg>\
	                            </span>\
							</a>\
							<a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Delete" data-id="'+ row.id + '" onclick = "DeleteformofUM(this)">\
	                            <span class="svg-icon svg-icon-md">\
	                                <svg xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" width="24px" height="24px" viewBox="0 0 24 24" version="1.1">\
	                                    <g stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">\
	                                        <rect x="0" y="0" width="24" height="24"/>\
	                                        <path d="M6,8 L6,20.5 C6,21.3284271 6.67157288,22 7.5,22 L16.5,22 C17.3284271,22 18,21.3284271 18,20.5 L18,8 L6,8 Z" fill="#000000" fill-rule="nonzero"/>\
	                                        <path d="M14,4.5 L14,4 C14,3.44771525 13.5522847,3 13,3 L11,3 C10.4477153,3 10,3.44771525 10,4 L10,4.5 L5.5,4.5 C5.22385763,4.5 5,4.72385763 5,5 L5,5.5 C5,5.77614237 5.22385763,6 5.5,6 L18.5,6 C18.7761424,6 19,5.77614237 19,5.5 L19,5 C19,4.72385763 18.7761424,4.5 18.5,4.5 L14,4.5 Z" fill="#000000" opacity="0.3"/>\
	                                    </g>\
	                                </svg>\
	                            </span>\
							</a>\
						';
                    },
                }],
            });
        }

    };

}();

jQuery(document).ready(function () {
    UserMasterdatatable.init();
});

function EditformofUM(element) {
    const GetById = element.dataset.id;
    if (!GetById) {
        console.error("User id is missing.");
        return;
    }
    $.ajax({
        url: "/UserMaaster/GetByUserId",
        type: "Get",
        data: { ID: GetById },
        success: function (response) {
            if (response.data.length > 0) {
                const data = response.data[0];
                console.log("User Data", data)
                $('#UserId').val(data.id);
                $('#NameId').val(data.fulL_NAME);
                $('#EmailId').val(data.email);
                $('#PhoneId').val(data.phonE_NO);
                $('#AddressId').val(data.address);
                $('#RoleId').val(data.rolE_ID);
                $('#PassId').val(data.pass);
                $('#ActiveId').val(data.isactive);
                $('#CreateId').val(data.createD_DATE);



                $('#exampleModalCenter').modal('show');

            }
            else {
                console.warn("No data found for the given User Id.");
            }
        },
        error: function () {
            console.error("AJAX Error:", status, error);
        },

    });

}

function DeleteformofUM(element) {
    const Delete = element.dataset.id;
    if (!Delete) {
        console.error("User id is missing.");
        return;
    }
    swal.fire({
        title: "Are you sure?",
        text: "You wont be able to revert this!",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes, delete it!"
    }).then(function (result) {
        if (result.value) {
            $.ajax({
                url: "/UserMaaster/Delete",
                type: "Post",
                data: { ID: Delete },
                success: function (response) {
                    if (response.status = true) {
                        swal.fire(
                            "Deleted!",
                            "Your file has been deleted.",
                            "success"
                        )
                        location.reload();
                    }
                    else {
                        console.warn("No data found for the given User Id.");
                    }
                },
                error: function () {
                    console.error("AJAX Error");
                },

            });
        }
    });
}


$("#resetbtn").click(function () {
    $("#resetId").click();
    location.reload();
});