

jQuery(document).ready(function () {
    $('#FormOtp').hide();
    $('#FormPassword').hide();
});  

function Email() {
    var EmailName = document.getElementById("EmailName").value;
    if (!EmailName) {
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
                url: "/OTP/OTPSENDER",
                type: "Post",
                data: { EMAIL: EmailName },
                success: function (response) {
                    $('#FormOtp').show();
                    $('#formEmail').hide();
                    if (response.status = true) {
                        swal.fire(
                            "Deleted!",
                            "Your file has been deleted.",
                            "success"
                        )
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



function NewOTP() {
    var OneTime = document.getElementById("OneTime").value;
    if (!OneTime) {
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
                url: "/OTP/OTPSENDER",
                type: "Post",
                data: { OTP: OneTime },
                success: function (response) {
                    $('#FormOtp').hide();
                    $('#FormPassword').show();
                    if (response.status = true) {
                        swal.fire(
                            "Deleted!",
                            "Your file has been deleted.",
                            "success"
                        )
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

function Password() {
    var NewPassword = document.getElementById("NewPassword").value;
    if (!NewPassword) {
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
                url: "/OTP/OTPSENDER",
                type: "Post",
                data: { PASS: NewPassword },
                success: function (response) {

                    if (response.status = true) {
                        swal.fire(
                            "Deleted!",
                            "Your file has been deleted.",
                            "success"
                        )

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

function NewOTP() {
        const OTPVER = document.getElementById("OneTime").value;
        const EmailOTP = document.getElementById("EmailName").value;
        if (!OTPVER) {
            console.error("OTP is missing.");
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
                    url: "/OTP/otpverification",
                    type: "Post",
                    data: { OTP: OTPVER, EMAIL: EmailOTP },
                    success: function (response) {
                        $('#FormOtp').hide();
                        $('#FormPassword').show();
                        if (response.status = true) {
                            swal.fire(
                                "Deleted!",
                                "Your file has been deleted.",
                                "success"
                            )

                        }
                        else {
                            console.warn("No data found for the given Event Id.");
                        }
                    },
                    error: function () {
                        console.error("AJAX Error");
                    },

                });
            }
        });
 }


function Password() {
    const OTPVER = document.getElementById("NewPassword").value;
    const EmailOTP = document.getElementById("EmailName").value;
    
    if (!OTPVER) {
        console.error("OTP is missing.");
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
                url: "/OTP/UpdatePassword",
                type: "Post",
                data: { PASS: OTPVER, EMAIL: EmailOTP },
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
                        console.warn("No data found for the given Event Id.");
                    }
                },
                error: function () {
                    console.error("AJAX Error");
                },

            });
        }
    });
}

