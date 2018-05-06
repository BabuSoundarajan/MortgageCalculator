$(document).ready(function () {

    $("#amount").maskMoney(); //money formatting

    $("input.numbers").on("keypress paste", (function (e) {
        return /\d/.test(String.fromCharCode(e.keyCode));
    }));

    $("#calculate").on("click", function (e) {
        var amount = $("#amount").maskMoney('unmasked')[0].toFixed(2);
        var interest = $("#mortgageType").val();
        var mortgageType = $("#mortgageType").find("option:selected").text();
        var years = $("#years").val();
        var months = years * 12;
        var monthlyInterest;
        var TotalInterest;
        var TotalLoanAmount;

        //Validations
        if (parseFloat(amount) < 0 || parseFloat(interest) <= 0 || parseFloat(years) <= 0) {
            $(".error-message").fadeIn("slow").removeClass("hidden");
            setTimeout(function () {
                $(".error-message").fadeOut("slow");
            }, 5000);
        }
        else {
            //Calculation
            monthlyInterest = getMonthlyPayment(amount, (interest / 100) / 12, months);
            TotalInterest = (monthlyInterest * months).toFixed(2);
            TotalLoanAmount = (parseFloat(TotalInterest) + parseFloat(amount)).toFixed(2);
            $(".result-summary").fadeIn("slow").removeClass("hidden");
            $("#monthlyAmount, #monthlyLoanAmount").append(monthlyInterest);
            $("#totalInterestAmount").append(TotalInterest);
            $("#loanPeriod").append(years);
            $("#loanAmount").append(amount);
            $("#interestRate").append(mortgageType);
            $("#loanTerm").append(years);
            $("#totalLoanAmount").append(TotalLoanAmount);
            $("#totalLoanInterest").append(TotalInterest);
            

            resetFields();

            $('html, body').animate({
                scrollTop: $(".result-summary").offset().top
            }, 2000);

            //Chart for summary result

            var ctx = $("#resultChart");
          
            var pieChart = new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: ["Loan Amount", "Total Interest"],
                    datasets: [{
                        data: [amount, TotalInterest],
                        backgroundColor: poolColors(2),
                        options: [
                            {
                                cutoutPercentage: 40,
                                rotation: -0.5 * Math.PI,
                                responsive: true,
                            }
                        ]

                    }]
                }
            });
        }
    });

    $("#newCalculation").on("click", function (e) {
        $(".result-summary").fadeOut("slow").removeClass("hidden");
        $('html, body').animate({
            scrollTop: $(".calculation-section").offset().top
        }, 2000);
    });

    $("#print").on("click", function (e) {
        window.print();
    });


    function resetFields() {
        $("#amount").val('');
        $("#mortgageType").val($("#mortgageType option:first").val());
        $("#years").val('');
    }

    function getMonthlyPayment(amount, interest, period) {
        amount = parseFloat(amount);
        interest = parseFloat(interest);
        period = parseFloat(period);

        var _return = ((amount * Math.pow(1 + interest, period)) / ((Math.pow((1 + interest), period) - 1) / ((1 + interest) - 1)));
        _return = _return.toFixed(2);
        return _return;
    }

    function poolColors(a) {
        var pool = [];
        for (i = 0; i < a; i++) {
            pool.push(dynamicColors());
        }
        return pool;
    }

    function dynamicColors() {
        var r = Math.floor(Math.random() * 255);
        var g = Math.floor(Math.random() * 255);
        var b = Math.floor(Math.random() * 255);
        return "rgb(" + r + "," + g + "," + b + ")";
    }
});


