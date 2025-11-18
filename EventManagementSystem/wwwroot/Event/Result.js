

var Resultdatatable = function () {

    // demo initializer
    return {
        EventJSONArray: [],

        init: function () {
            this.fetchcashierData();
        },

        fetchcashierData: async function () {
            try {
                const response = await fetch('/Result/GetAllResult');
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }

                const CashierResponseData = await response.json();

                console.log(CashierResponseData);

                this.EventJSONArray = CashierResponseData.data;

                // Initialize the datatable
                this.initializeDatatable();
            } catch (error) {
                console.error('Fetch error:', error);
            }
        },

        initializeDatatable: function () {
            var datatable = $('#ResultDataTable').KTDatatable({
                // datasource definition
                data: {
                    type: 'local',
                    source: this.EventJSONArray,
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
                    field: 'event_Name',
                    title: 'Event_Name',
                }, {
                    field: 'first',
                    title: 'first',
                }, {
                    field: 'second',
                    title: 'second',
                }, {
                    field: 'third',
                    title: 'third',
                }, {
                    field: 'winner',
                    title: 'winner',
                }, {
                    field: 'createDate',
                    title: 'createDate',
                }, {
                    field: 'updatedBy',
                    title: 'updatedBy',
                }, {
                    field: 'remark',
                    title: 'remark',

                    sortable: false,
                    width: 125,
                    overflow: 'visible',
                    autoHide: false,
                    template: function (row) {
                        return '\
							<a href="javascript:;" class="btn btn-sm btn-clean btn-icon mr-2" title="Edit details" data-id="'+ row.id + '" onclick = " EditOfResult(this)" >\
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
							<a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Delete" data-id="'+ row.id + '" onclick = "DeleteformofResult(this)">\
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
    Resultdatatable.init();
});

function EditOfResult(element) {
    const GetById = element.dataset.id;
  
    if (!GetById) {
        console.error("User id is missing.");
        return;
    }
    $.ajax({
        url: "/Result/EditResult",
        type: "Get",
        data: { Id: GetById },
        success: function (response) {

            if (response.data.length > 0) {
                const data = response.data[0];
                console.log("Result data", data)
              
                $('#Event_NameId').val(data.event_ID).selectpicker("refresh");   
                $('#resultId').val(data.id).selectpicker("refresh");   

                GetAllUsers(function () {
                    $('#firstwinnerid').val(data.first).selectpicker("refresh");
                    $('#secondwinnerid').val(data.second).selectpicker("refresh");
                    $('#thirdwinnerid').val(data.third).selectpicker("refresh");  
                    $('#winnerID').val(data.winner).selectpicker("refresh");    
                    $('#remarkID').val(data.remark).selectpicker("refresh");  

                });
              
                $('#exampleModalCenter').modal('show');
            }
            else {
                console.warn("No data found for the given User Id.");
            }
        },
        error: function ( xhr,status,error) {
            console.error("AJAX Error:", status, error);
        },

    });

}

function DeleteformofResult(element) {
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
                url: "/Result/Delete",
                type: "Post",
                data: { Id: Delete },
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


function GetAllUsers(callback) {
    var EventID = document.getElementById("EventNameId").value;
    $.ajax({
        url: '/Result/GetAllUserOption',
        type: 'GET',
        data: { Event_ID: EventID },
        success: function (data) {
            $('#firstwinnerid').empty().append('<option value="">-- Select Company --</option>');
            $('#secondwinnerid').empty().append('<option value="">-- Select Company --</option>');
            $('#thirdwinnerid').empty().append('<option value="">-- Select Company --</option>');
            $('#winnerID').empty().append('<option value="">-- Select Company --</option>');
            $('#remarkID').empty().append('<option value="">-- Select Company --</option>');
            $.each(data.data, function (i, company) {
                $('#firstwinnerid').append(`<option value="${company.user_Id}">${company.fulL_NAME}</option>`);
                $('#secondwinnerid').append(`<option value="${company.user_Id}">${company.fulL_NAME}</option>`);
                $('#thirdwinnerid').append(`<option value="${company.user_Id}">${company.fulL_NAME}</option>`);
                $('#winnerID').append(`<option value="${company.user_Id}">${company.fulL_NAME}</option>`);
                $('#remarkID').append(`<option value="${company.user_Id}">${company.fulL_NAME}</option>`);
            });

            $('.selectpicker').selectpicker('refresh');
            if (typeof callback === "function") {
                callback();
            }
        }
    });
}


function firstWinner() {

    var firstSelect = document.getElementById("firstwinnerid");
    var winnerSelect = document.getElementById("winnerID");

    var selectedValue = firstSelect.value;
    var selectedText = firstSelect.options[firstSelect.selectedIndex].text;


    winnerSelect.innerHTML = "";


    var newOption = document.createElement("option");
    newOption.value = selectedValue;
    newOption.text = selectedText;


    winnerSelect.appendChild(newOption);
}



