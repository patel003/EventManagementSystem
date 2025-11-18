var BookedEvents = function () {

    // demo initializer
    return {
        CashierJSONArray: [],

        init: function () {
            this.fetchcashierData();
        },

        fetchcashierData: async function () {
            try {
                const response = await fetch('/EventMaster/BookedEvents');
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
            var datatable = $('#BookedEvetns').KTDatatable({
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
                    field: 'Status',
                    title: 'Status',

                    sortable: false,
                    width: 125,
                    overflow: 'visible',
                    autoHide: false,
                    template: function (row) {
                        return '\
							<a href="javascript:;" class="btn btn-sm btn-clean btn-icon" title="Delete" data-id="'+ row.event_ID + '" onclick = "DeleteMyEvent(this)">\
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


              
                }],


            });
        }

    };

}();

jQuery(document).ready(function () {
    BookedEvents.init();
});






function DeleteMyEvent(element) {
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
                url: "/EventMaster/Delete",
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