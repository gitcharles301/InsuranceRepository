$(document).ready(function () {
    $(document).ajaxStart(function () {
        $("#wait").css("display", "block");
    });
    $(document).ajaxComplete(function () {
        $("#wait").css("display", "none");
    });
    $("#lblPageName").text("Create Policy");
    $("#divDashboardHeader,#divDashboard").hide();
    $('.date').datepicker({
        dateFormat: 'dd/mm/yy',
        changeYear: true,
        maxDate: '0'
    });


    $("#tabBasicDetail").click(function () {
        TabVisiable('BD');
    });

    $("#tabPersonalDetail").click(function () {
        TabVisiable('PD');
    });

    $("#tabNomineeDetail").click(function () {
        TabVisiable('ND');
    });


    $("#tabMedicalDetail").click(function () {
        TabVisiable('MD');
    });

    $("#tabPolicyDetail").click(function () {
        TabVisiable('PLD');
    });

    $('#tabDocumentUpload').click(function () {
        TabVisiable('DU');
    });

    $(".tel").keydown(function (e) {
        // Allow: backspace, delete, tab, escape, enter and .
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110]) !== -1 ||
            // Allow: Ctrl+A, Command+A
            (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
            // Allow: home, end, left, right, down, up
            (e.keyCode >= 35 && e.keyCode <= 40)) {
            // let it happen, don't do anything
            return;
        }
        // Ensure that it is a number and stop the keypress
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });

    // Basic Detail Save Click
    $("#btnBasicDetail").click(function () {

        if ($("#txtFirstName").val() == "") {
            $("#revFirstName").show();
            $("#revFirstName").html("Please enter FirstName!");
            return false;
        }
        else if ($("#txtLastName").val() == "") {
            $("#revLastName").show();
            $("#revLastName").html("Please enter LastName!");
            return false;
        }
        else if ($("input[name='gender']:checked").val() == -1) {
            $("#revGender").show();
            $("#revGender").html("Please enter Gender!");
            return false;
        }
        else if ($("#txtDateofBirth").val() == "") {
            $("#revDateofBirth").show();
            $("#revDateofBirth").html("Please enter DateofBirth!");
            return false;
        }
        else if ($("#txtEmailId").val() == "") {
            $("#revEmailValidator").show();
            $("#revEmailValidator").html("Please enter EmailID!");
            return false;
        }
        else if ($("#txtMobileNo").val() == "") {
            $("#revMobileNo").show();
            $("#revMobileNo").html("Please select MobileNo!");
            return false;
        }
        else if ($("#ddlMailingState option:selected").text() == "Select") {
            $("#rfvMailingState").show();
            $("#rfvMailingState").html("Please select State!");
            return false;
        }

        else {
            var InsurrerDetail = {
                FirstName: $("#txtFirstName").val(),
                MiddleName: $("#txtMiddleName").val(),
                LastName: $("#txtLastName").val(),
                EmailID: $("#txtEmailId").val(),
                MobileNo: $("#txtMobileNo").val(),
                State: $("#ddlMailingState option:selected").val(),
                AgentId: $("#hdnUserid").val(),
                DateofBirth: $("#txtDateofBirth").val(),
                Gender: $("input[name='gender']:checked").val()
            };
            var baseapiurl = getWebapiBaseUrl() + 'api/InsuranceAPI/CreateBasicDetail';
            debugger;
            $.ajax({
                url: baseapiurl,
                data: InsurrerDetail,
                type: 'POST',
                dataType: 'json',
                success: function (jData) {
                    $('#hdnTempPolicyNo').val(jData);
                    TabVisiable('PD');
                },
                error: function (err) {
                    // alert(err);
                }
            });
        }
    });

    // Personal Detail Save
    $("#btnPersonalDetail").click(function () {

        if ($("#txtAddress").val() == "") {
            $("#revAddress").show();
            $("#revAddress").html("Please enter Address");
            return false;
        }
        else if ($("#ddlCity option:selected").text() == "Select") {
            $("#revCity").show();
            $("#revCity").html("Please select City!");
            return false;
        }
        else if ($("#txtPincode").val() == "") {
            $("#revPincode").show();
            $("#revPincode").html("Please enter Pincode!");
            return false;
        }
        else if ($("#txtOccupation").val() == "") {
            $("#revOccupation").show();
            $("#revOccupation").html("Please enter Occupation!");
            return false;
        }
        else if ($("#txtAadhar").val() == "") {
            $("#revAadhar").show();
            $("#revAadhar").html("Please select Aadhar no!");
            return false;
        }
        else if ($("#txtPanNo").val() == "") {
            $("#revPanNo").show();
            $("#revPanNo").html("Please select Panno!");
            return false;
        }
        else {
            var PersonalDetail = {
                Address: $("#txtAddress").val(),
                Pincode: $("#txtPincode").val(),
                PersonalOccupation: $("#txtOccupation").val(),
                AadharNo: $("#txtAadhar").val(),
                PanNo: $("#txtPanNo").val(),
                City: $("#ddlCity option:selected").val(),
                CreatedBy: $("#hdnUserid").val(),
                TempPolicyNo: $('#hdnTempPolicyNo').val()
            };
            var baseapiurl = getWebapiBaseUrl() + 'api/InsuranceAPI/CreatePersonalDetail';

            $.ajax({
                url: baseapiurl,
                data: PersonalDetail,
                type: 'POST',
                dataType: 'json',
                success: function (jData) {
                    TabVisiable('ND');
                },
                error: function (err) {

                }
            });
        }
    });


    //Noimee Detail Save Click

    $("#btnNomineeDetail").click(function () {

        if ($("#txtNomineeFirstName").val() == "") {
            $("#revNomineeFirstName").show();
            $("#revNomineeFirstName").html("Please enter FirstName!");
            return false;
        }
        else if ($("#txtNomineeLastName").val() == "") {
            $("#revNomineeLastName").show();
            $("#revNomineeLastName").html("Please enter LastName!");
            return false;
        }
        else if ($("#txtNomineeDateofBirth").val() == "") {
            $("#revNomineeDateofBirth").show();
            $("#revNomineeDateofBirth").html("Please enter DateofBirth!");
            return false;
        }
        else if ($("#txtNomineeAddress").val() == "") {
            $("#revNomineeAddress").show();
            $("#revNomineeAddress").html("Please enter Address!");
            return false;
        }
        else if ($("#txtNomineePincode").val() == "") {
            $("#revNomineePincode").show();
            $("#revMobileNo").html("Please select Pincode!");
            return false;
        }
        else if ($("#ddlNomineeCity option:selected").text() == "Select") {
            $("#revNomineeCity").show();
            $("#revNomineeCity").html("Please select City!");
            return false;
        }

        else {
            var NomineeDetail = {
                NomineeFirstName: $("#txtNomineeFirstName").val(),
                NomineeMiddleName: $("#txtNomineeMiddleName").val(),
                NomineeLastName: $("#txtNomineeLastName").val(),
                NomineeDateofBirth: $("#txtNomineeDateofBirth").val(),
                NomineeAddress: $("#txtNomineeAddress").val(),
                NomineeCity: $("#ddlNomineeCity option:selected").val(),
                NomineePincode: $("#txtNomineePincode").val(),
                CreatedBy: $("#hdnUserid").val(),
                TempPolicyNo: $('#hdnTempPolicyNo').val()
            };
            var baseapiurl = getWebapiBaseUrl() + 'api/InsuranceAPI/CreateNomineeDetail';

            $.ajax({
                url: baseapiurl,
                data: NomineeDetail,
                type: 'POST',
                dataType: 'json',
                success: function (jData) {
                    TabVisiable('MD');
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
    });

    //Medical Detail Save Click

    $("#btnMedicalDetail").click(function () {

        if ($("#txtCheckupDate").val() == "") {
            $("#revCheckupDate").show();
            $("#revCheckupDate").html("Please enter CheckupDate!");
            return false;
        }
        else if ($("#txtHospitalName").val() == "") {
            $("#revHospitalName").show();
            $("#revHospitalName").html("Please enter HospitalName!");
            return false;
        }
        else if ($("#txtDoctorName").val() == "") {
            $("#revDoctorName").show();
            $("#revDoctorName").html("Please enter DoctorName!");
            return false;
        }
        else if ($("#txtReportComments").val() == "") {
            $("#txtReportComments").show();
            $("#txtReportComments").html("Please enter Medical Report Description!");
            return false;
        }
        else {
            var MedicalDetail = {
                MedicalCheckupDate: $("#txtCheckupDate").val(),
                HospitalName: $("#txtHospitalName").val(),
                DoctorName: $("#txtDoctorName").val(),
                MedicalReportComment: $("#txtReportComments").val(),
                CreatedBy: $("#hdnUserid").val(),
                TempPolicyNo: $('#hdnTempPolicyNo').val()
            };
            var baseapiurl = getWebapiBaseUrl() + 'api/InsuranceAPI/CreateMedicalDetail';

            $.ajax({
                url: baseapiurl,
                data: MedicalDetail,
                type: 'POST',
                dataType: 'json',
                success: function (jData) {
                    TabVisiable('DU');
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
    });
    //Policy Detail Save Click

    $("#btnPolicyDetail").click(function () {

        if ($("#txtSumAssured").val() == "") {
            $("#revSumAssured").show();
            $("#revSumAssured").html("Please enter SumAssured");
            return false;
        }
        else if ($("#ddlPolicyPaymentMode option:selected").text() == "Select") {
            $("#revPolicyPaymentMode").show();
            $("#revPolicyPaymentMode").html("Please select Policy PaymentMode!");
            return false;
        }
        else if ($("#ddlPolicyTerm option:selected").text() == "Select") {
            $("#revPolicyTerm").show();
            $("#revPolicyTerm").html("Please select Policy Term!");
            return false;
        }
        else if ($("#ddlSmoker option:selected").text() == "Select") {
            $("#revSmoker").show();
            $("#revSmoker").html("Please select Smoker Status!");
            return false;
        }
        else {
            var PolicyDetail = {
                SumAssured: $("#txtSumAssured").val(),
                SmokerStatus: $("#ddlSmoker option:selected").val(),
                PolicyPaymentMode: $("#ddlPolicyPaymentMode option:selected").val(),
                PolicyTerm: $("#ddlPolicyTerm option:selected").val(),
                PolicyCreatedBy: $("#hdnUserid").val(),
                TempPolicyNo: $('#hdnTempPolicyNo').val(),
                PolicyTypeId: $('#ddlPolicyTypeId option:selected').val(),
                PremiumAmount: $('#txtPremiumAmount').val()

            };
            var baseapiurl = getWebapiBaseUrl() + 'api/InsuranceAPI/CreatePolicyDetail';

            $.ajax({
                url: baseapiurl,
                data: PolicyDetail,
                type: 'POST',
                dataType: 'json',
                success: function (jData) {
                    alert('Policy Information Updated Successfully.')
                    $('input[type=text], select', $('#BasicDetail, #PersonalDetail, #NomineeDetail, #MedicalDetail, #PolicyDetail')).val('');
                    window.location.href = window.location.href;
                },
                error: function (err) {

                }
            });
        }
    });

    //Document Uplaod Save Click

    $("#btnDocumentUpload").click(function () {
        if ($('#AadharDocumentfile').val() == '') {
            $('#revAadharDocumentfile').show();
            $('#revAadharDocumentfile').html("Please select Aadhar Document!");
            return false;
        }
        else if ($('#PanDocumentfile').val() == '') {
            $('#revPanDocumentfile').show();
            $('#revPanDocumentfile').html("Please select PAN Document!");
            return false;
        }
        else if ($('#MedicalDocumentfile').val() == '') {
            $('#revMedicalDocumentfile').show();
            $('#revMedicalDocumentfile').html("Please select Medical Report Document!");
            return false;
        }
        else {
            PostSupportingDocument();
        }
    });

    $("#btnPersonalPrevious").click(function () {
        TabVisiable('BD');
    });

    $("#btnNomineePrevious").click(function () {
        TabVisiable('PD');
    });

    $("#btnMedicalPrevious").click(function () {
        TabVisiable('ND');
    });

    $("#btnPolicyDetailPrevious").click(function () {
        TabVisiable('DU');
    });


    $("#btnDocumentUploadPrevious").click(function () {
        TabVisiable('MD');
    });


});
function ClearBasicDetailControls() {
    $("#txtFirstName").val('');
    $("#txtMiddleName").val('');
    $("#txtLastName").val('');
    $("#txtEmailId").val('');
    $("#txtMobileNo").val('');
    $("#ddlMailingState").val(0);
    $("#txtDateofBirth").val('');
    $("input[name='gender']:checked").val(-1);
}
function ClearPersonalDetailControls() {
    $("#txtAddress").val('');
    $("#txtPincode").val('');
    $("#txtOccupation").val('');
    $("#txtAadhar").val('');
    $("#txtPanNo").val('');
    $("#ddlCity").val(0);
}
function ClearNoimeeDetailControls() {
    $("#txtNomineeFirstName").val('');
    $("#txtNomineeMiddleName").val('');
    $("#txtNomineeLastName").val('');
    $("#txtNomineeDateofBirth").val('');
    $("#txtNomineeAddress").val('');
    $("#ddlNomineeCity").val(0);
    $("#txtNomineePincode").val('');
    $('#hdnTempPolicyNo').val('');

}

function ClearMedicalDetailControls() {
    $("#txtCheckupDate").val('');
    $("#txtHospitalName").val('');
    $("#txtDoctorName").val('');
    $("#txtReportComments").val('');

}
function ClearPolicyDetailControls() {
    $("#txtAddress").val('');
    $("#ddlSmoker").val(0);
    $("#ddlPolicyPaymentMode").val(0);
    $("#ddlPolicyTerm").val(0);
    $('#hdnTempPolicyNo').val(0);
    $('#ddlPolicyTypeId').val(0);
    $('#PremiumAmount').val('');
}
function formatJSONDate(jsonDate) {
    var newDate = dateFormat(jsonDate, "mm/dd/yyyy");
    return newDate;
}
function getWebapiBaseUrl() {
   // var uri = 'http://localhost/InsuranceIssueApp.WebAPI/';
    var uri = 'http://insurancewebapi.azurewebsites.net/';
    return uri;
}
function loadAllPolicyDetail() {
    var TempPolicyNo = $('#hdnTempPolicyNo').val();
    if (TempPolicyNo != 0) {
        $.ajax({
            url: '/Policy/loadTabPolicyDetail?tempPolicyNo=' + TempPolicyNo,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                if (data != null) {
                    TabVisiable('BD');
                    $("#txtFirstName").val(data.FirstName);
                    $("#txtMiddleName").val(data.MiddleName);
                    $("#txtLastName").val(data.LastName);
                    $("#txtEmailId").val(data.EmailID);
                    $("#txtMobileNo").val(data.MobileNo);
                    $("#ddlMailingState").val(data.State);                   
                    var date = new Date(moment(data.DateofBirth).toDate());
                    var sday = date.getDate() < 10 ? '0' + date.getDate() : date.getDate();
                    var smonth = (date.getMonth() + 1) < 10 ? '0' + (date.getMonth() + 1) : (date.getMonth() + 1);
                    var syear = date.getFullYear();
                    var sDate = sday + '/' + smonth + '/' + syear;
                    // date = new Date(sDate);(date.getMonth() + 1)
                    $("#txtDateofBirth").val(sDate);                    
                    if (data.Gender == 1)
                        $('#rdMale').prop('checked', true);
                    else if (dat.Gender == 2)
                        $('#rdFemale').prop('checked', true);
                    else 
                        $('#rdTransgender').prop('checked', true);                   
                }
            },
            error: function (err) {
                alert(err);
            }
        });
    }
}
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;

    return true;
}


function ValidateEmailID(txtEmailID) {

    var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;

    if (txtEmailID.value == "") {

        txtEmailID.style.border = "";

        return true;

    }

    else if (filter.test(txtEmailID.value)) {

        txtEmailID.style.border = "";

        return true;

    }

    else {

        txtEmailID.style.borderColor = "red";

        return false;

    }

}
function TabVisiable(tabName) {
    $('#BasicDetail,#PersonalDetail,#NomineeDetail,#MedicalDetail,#PolicyDetail,#DocumentUpload').hide();
    $('#tabBasicDetail,#tabPersonalDetail,#tabNomineeDetail,#tabMedicalDetail,#tabPolicyDetail,#tabDocumentUpload').removeClass("btn-primary").addClass("btn-secondary");
    if (tabName == 'BD') {
        $('#BasicDetail').show();
        $("#tabBasicDetail").removeClass("btn-secondary").addClass("btn-primary");
    }
    else if (tabName == 'PD') {
        $('#PersonalDetail').show();
        $("#tabPersonalDetail").removeClass("btn-secondary").addClass("btn-primary");
    }
    else if (tabName == 'ND') {
        $('#NomineeDetail').show();
        $("#tabNomineeDetail").removeClass("btn-secondary").addClass("btn-primary");
    }
    else if (tabName == 'MD') {
        $('#MedicalDetail').show();
        $("#tabMedicalDetail").removeClass("btn-secondary").addClass("btn-primary");
    }
    else if (tabName == 'DU') {
        $('#DocumentUpload').show();
        $("#tabDocumentUpload").removeClass("btn-secondary").addClass("btn-primary");
    }
    else if (tabName == 'PLD') {
        $('#PolicyDetail').show();
        $("#tabPolicyDetail").removeClass("btn-secondary").addClass("btn-primary");
    }
}
function PostSupportingDocument() {
    $("#divError").hide();

    var formData = new FormData();
    var file = document.getElementById("AadharDocumentfile").files[0];

    formData.append("FileUpload", file);
    formData.append("FileUpload1", document.getElementById("PanDocumentfile").files[0]);
    formData.append("FileUpload2", document.getElementById("MedicalDocumentfile").files[0]);
    formData.append("ID", $('#hdnTempPolicyNo').val());

    if (file.type != null) {
        $.ajax({
            url: '/Policy/UploadSupportingDocuments',
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            data: formData,
            type: "POST",
            success: function (jData) {
                if (jData != null) {
                    $("#wait").css("display", "none");                    
                    var table = $('#dataTable');
                    table.html('');
                    var tableMarkup = "<thead class='thead-dark'><tr><td>ID</td><td>Display Name</td><td>FileName</td></tr></thead>";

                    $.each(jData, function () {
                        tableMarkup += "<tr><td>" + this.FileId + "</td>";
                        tableMarkup += "<td>" + this.DisplayFileName + "</td>";
                        tableMarkup += "<td>" + this.FileName + "</td></tr>";
                    });

                    table.append(tableMarkup);

                    TabVisiable('PLD');
                    $("#divError").hide();
                    //$('#tbody').html(strHtml);
                }
                else {
                  //  $("#divError").show();
                  //  $("#divError").html('Enquiry uploaded successfully.');
                }
            }
        });
    }
}
