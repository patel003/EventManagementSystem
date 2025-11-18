var myEventdatatable = function () {

    // demo initializer
    return {
        CashierJSONArray: [],

        init: function () {
            this.fetchcashierData();
        },

        fetchcashierData: async function () {
            try {
                const response = await fetch('/EventMaster/GetMyEvents');
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
            var datatable = $('#MyEvent').KTDatatable({
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
                    input: $('#Cashier_DataTable_search_query'),
                    key: 'generalSearch'
                },

                // columns definition
                columns: [{
                    field: 'event_ID',
                    title: 'event_ID',
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
                    title: 'event_Name',
                }, {
                    field: 'price',
                    title: 'price',
                }, {

                    field: 'event_discription',
                    title: 'event_discription',
                }, {
                    field: 'event_Date',
                    title: 'event_Date',
                }, {

                    field: 'organizer',
                    title: 'organizer',
                }, {

                    field: 'start_Time',
                    title: 'start_Time',

                }, {
                    field: 'event_category',
                    title: 'event_category',
                }, {

                    field: 'end_Time',
                    title: 'end_Time',
                }, {
                    field: 'mobile_No',
                    title: 'mobile_No',
                }, {
                    field: 'theme',
                    title: 'theme',
                }, {
                    field: 'organizer',
                    title: 'organizer',

                }, {
                    field: 'resultStatus',
                    title: 'result',
                    visible: false,
                    searchable: true,


                }, {
                    field: 'action',
                    title: 'Actions',

                    sortable: false,
                    width: 125,
                    overflow: 'visible',
                    autoHide: false,
                    template: function (row) {
                        return '\
							<a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Delete" data-id="'+ row.event_ID + '" onclick = "cancelMyEvent(this)">\
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
						'
                    },
                },




                {
                    field: 'result',
                    title: 'Result',

                    sortable: false,
                    width: 125,
                    overflow: 'visible',
                    autoHide: false,
                    template: function (row) {
                        if (row.resultStatus === 'Declared') {
                            return `
                                <a href="javascript:;" 
                                   class="btn btn-sm btn-clean btn-icon" 
                                   title="View Result"
                                   onclick="openModal(${row.event_ID})">
                                    <i class="la la-trophy text-primary fs-3"></i>
                                </a>
                            `
                        } else {
                            return `
                                <span class="badge bg-warning text-dark fw-bold">Pending</span>
                            `
                        }
                    }
                }],



            });
        }

    };

}();

jQuery(document).ready(function () {
    myEventdatatable.init();
});



function openModal(event_ID) {
    const eventId = event_ID;

    if (!eventId) {
        console.error("Missing event ID");
        return;
    }

    $.ajax({
        url: "/Result/ResultStatus",
        type: "Post",
        data: { Event_ID: eventId },
        success: function (response) {
            if (response && response.data && response.data.length > 0) {
                const data = response.data[0];
                console.log("Fetched Event Data:", data);

                $('#Event_Name').text(data.event_Name);
                $('#First').text(data.first);
                $('#Second').text(data.second);
                $('#Third').text(data.third);
                $('#Winner').text(data.first);

                $('#detailModal').modal('show');
            } else {
                console.warn("No data found for Event_ID:", event_ID);
            }
        },
        error: function (xhr, status, error) {
            console.error("AJAX Error:", status, error);
        }
    });
}







function Pay(element) {

    var priceId = element.dataset.priceId;
    var eventId = element.dataset.eventId;
    if (!eventId) {
        console.error("User id is missing.");
        return;
    }
    swal.fire({
        title: "Price:" + priceId,
        text: "You want to join this event!",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Pay Now !"
    }).then(function (result) {
        if (result.value) {
            $.ajax({
                url: "/EventMaster/InsertEvent",
                type: "Post",
                data: { Event_ID: eventId },
                success: function (response) {
                    if (response.code == 1) {
                        swal.fire(
                            "Paid!",
                            "You are join successfully.",
                            "success"
                        )
                        //MyEventDataTable.fetchcashierData();

                    }
                    else {
                        toastr.warning(response.message);
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


function cancelMyEvent(element) {
    var eventId = element.dataset.id;
    if (!eventId) {
        console.error("Event id is missing.");
        return;
    }

    swal.fire({
        title: "Are you sure?",
        text: "You want to cancel this booking?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes, cancel it!"
    }).then(function (result) {
        if (result.value) {
            $.ajax({
                url: "/EventMaster/CancelEvent",
                type: "POST",
                data: { Event_ID: eventId },
                success: function (response) {
                    if (response.status = true) {
                        swal.fire(
                            "Cancelled!",
                            "Your booking has been cancelled.",
                            "success"
                        );
                        location.reload();
                    } else {
                        console.warn("No data found for the given Event Id.");
                    }
                },
                error: function () {
                    console.error("AJAX Error");
                }
            });
        }
    });
}




$(document).ready(function () {

    $("#statusFilter").change(function () {

        var selectedStatus = $(this).val();
       
        // Datatable reload with status filter
        $("#MyEvent").KTDatatable().search(
            selectedStatus,
            "resultStatus"
        );
    });

});
