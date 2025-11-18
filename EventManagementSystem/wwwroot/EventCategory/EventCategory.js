var Categorydatatable = function () {

    // demo initializer
    return {
        CashierJSONArray: [],

        init: function () {
            this.fetchcashierData();
        },

        fetchcashierData: async function () {
            try {
                const response = await fetch('/EventCategory/GETALL');
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
            var datatable = $('#CategoryTable').KTDatatable({
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
                    field: 'categorY_ID',
                    title: 'categorY_ID',
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
                    field: 'categorY_NAME',
                    title: 'categorY_NAME',
                }, {
                    field: 'createD_DATE',
                    title: 'createD_DATE',
                }, {
                    field: 'updatE_DATE',
                    title: 'updatE_DATE',
                }, {
                    field: 'createD_BY',
                    title: 'createD_BY',
                }, {
                    field: 'isactive',
                    title: 'isactive',
              
              
                }, {
                    field: 'description',
                    title: 'description',

                   

                }, {
                    field: 'action',
                    title: 'Actions',
                    sortable: false,
                    width: 125,
                    overflow: 'visible',
                    autoHide: false,
                    template: function (row) {
                        return '\
							<a href="javascript:;" class="btn btn-sm btn-clean btn-icon mr-2" title="Edit details" data-id="'+ row.categorY_ID + '" onclick = "EventCategory(this)" >\
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
							<a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Delete" data-id="'+ row.categorY_ID + '" onclick = "DeleteformofEventCategory(this)">\
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
    Categorydatatable.init();
});

function EventCategory(element) {
    const CategoryID = element.dataset.id;
    if (!CategoryID) {
        console.error("User id is missing.");
        return;
    }
    $.ajax({
        url: "/EventCategory/getbyCATEGORYID",
        type: "Get",
        data: { CATEGORY_ID: CategoryID },
        success: function (response) {
            if (response.data.length > 0) {
                const data = response.data[0];
                console.log("Event_Category Data", data)
                $('#categroyId').val(data.categorY_ID);
                $('#category_Name').val(data.categorY_NAME);
                $('#DESCRIPTIONID').val(data.description);
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

function DeleteformofEventCategory(element) {
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
                url: "/EventCategory/Delete",
                type: "Post",
                data: { CATEGORY_ID: Delete },
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

$("#resetBtn").click(function () {
    $("#resetId").click();
    location.reload();
});