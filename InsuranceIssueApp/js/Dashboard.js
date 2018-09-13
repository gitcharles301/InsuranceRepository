$(document).ready(function () {
    $(document).ajaxStart(function () {
        $("#wait").css("display", "block");
    });
    $(document).ajaxComplete(function () {
        $("#wait").css("display", "none");
    });
    $("#lblPageName").text("My Policies");
   // GetTop5PolicyInQueue();
    dashboardchart();
    loadDashboardCount();

});

function getWebapiBaseUrl() {
  //  var uri = 'http://localhost:54118/';
    var uri = 'http://insurancewebapi.azurewebsites.net/';
    return uri;
}

function RedirectToViewPolicy(tempPolicyNo)
{
    location.href = '/Policy/Index?tempPolicyNo='+ tempPolicyNo;
}
function GetTop5PolicyInQueue() {   
   // var baseapiurl = getWebapiBaseUrl() + 'api/InsuranceAPI/GetTop5PolicyInQueue?loginid=' + $("#hdnUserid").val();
    //var baseapiurl = '@Url.Action("GetTop5PolicyInQueue", "Home")' + '?loginid=' + $("#hdnUserid").val();
    $.ajax({
        url: '/Home/GetTop5PolicyInQueue?loginid=' + $("#hdnUserid").val(),        
        type: 'GET',
        dataType: 'json',
        success: function (data) {
           
            var table = $('#dataTable');
            table.html('');
            var tableMarkup = "<tr><td>Temp.PolicyNo</td><td>FirstName</td><td>LastName</td><td>Email ID</td><td>Mobile No</td><td>Policy Status</td><td>Select</td></tr>";
           
            $.each(data, function () {
                tableMarkup = tableMarkup + "<tr><td>" + this.TempPolicyNo + "</td><td>" + this.FirstName + "</td><td>" + this.LastName + "</td><td>" + this.EmailID + "</td><td>" + this.MobileNo + "</td><td>" + this.PolicyStatusName + "</td>";
                tableMarkup += '<td><button type="button" onclick="RedirectToViolicy(' + this.Id + ')"  class="btn btn-danger" id=' + this.Id + '>View/Edit</button> </td></tr>';
               
            });

            table.append(tableMarkup);
                    // table.append('</table>');  
        },
        error: function (err) {

        }
    });

   
       
}

function dashboardchart()
{
    $("#wait").css("display", "block");
    $.ajax({
        url: '/Home/RepAgentPolicyMonthWise?agentid=' + $("#hdnUserid").val(),
        type: 'GET',
        dataType: 'json',
        success: function (jData) {
            if (jData != null && jData.length > 0) {
                var categoryArray = [];
                var dataArray = [];
                $.each(jData, function (i, d) { categoryArray.push(d.MonthName); dataArray.push(parseInt(d.Total)); });

                var subtitle = {
                    text: ''
                };
                var xAxis = {
                    categories: categoryArray
                };
                var yAxis = {
                    title: {
                        text: 'Policy Created Count '
                    },
                    plotLines: [{
                        value: 0,
                        width: 1,
                        color: '#808080'
                    }]
                };

                var tooltip = {
                    valueSuffix: ''
                }
                var legend = {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle',
                    borderWidth: 0
                };
                var series = [{
                    name: 'No.of policies',
                    data: dataArray,
                    color: '#FFC300'
                }
                ];
                var chart = {
                    type: 'column'
                };


                var json = {};
                json.title = title;
                json.subtitle = subtitle;
                json.xAxis = xAxis;
                json.yAxis = yAxis;
                json.tooltip = tooltip;
                json.legend = legend;
                json.series = series;
                json.chart = chart;

                $('#divContainerChart').highcharts(json);
                $('.highcharts-credits').text('');
                $("#wait").css("display", "none");
            }
            else {
                $("#divError").show();
                $("#divError").html("No Records Found!");
                $("#wait").css("display", "none");
            }

        },
        error: function (err) {
            $("#wait").css("display", "none");
        }
    });

    var title = {
        text: 'Monthwise Policy Count'
    };
    
  // alert($('.highcharts-credits').text(''));
}
function loadDashboardCount() {
    $("#wait").css("display", "block");
       
  //  var baseapiurl = 'http://localhost/InsuranceIssueApp.WebAPI/api/InsuranceAPI/GetUserDashboardDetail?userid=' + $("#hdnUserid").val();
    var baseapiurl = '/Home/GetUserDashboardDetail?agentid=' + $("#hdnUserid").val();
        debugger;
        $.ajax({
            url: baseapiurl,
            data: { userid: $("#hdnUserid").val() },
            type: 'POST',
            dataType: 'json',
            success: function (jData) {
                
                $("#lblTotal").html(jData.Total);
                $("#lblUnwriting").html(jData.UnwritingReview);
                $("#lblApproved").html(jData.Approved);
                $("#lblPolicyGen").html(jData.PolicyDocGenerated);
                //if (jData != null && jData.length > 0) {
                               
                $("#wait").css("display", "none");
                      
                       
                   
                //}
                //else {
                //    $("#lblTotal").html(0);
                //    $("#lblUnwriting").html(0);
                //    $("#lblApproved").html(0);
                //    $("#lblPolicyGen").html(0);
                //}
            },
            error: function (err) {
                $("#wait").css("display", "none");
            }
        });
   
}