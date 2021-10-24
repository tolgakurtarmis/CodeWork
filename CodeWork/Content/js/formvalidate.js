/*
FormValidate 2.2

<script src='http://library.talk.com.tr/formvalidate/formvalidate.js'></script>
Projeye JavaScript dosyası eklendiğinde otomatik olarak css özellikleri de yüklenmekte istenirse css class isimleri kullanılarak projeye göre hata mesajı görüntüsü düzenlenebilir.

doldurulması zorunlu alanlarda "required" bulunmalı

data-error="Hata mesajı" 	//Yazılmamışsa varsayılan hata mesajı görüntülenir
data-min="5"            	//En az 5 karakter girilmiş olmalı
data-max="10"           	//En fazla 10 karakter girilmiş olmalı
type="email"            	//Eposta formatı olmalı
data-type="tckimlik"    	//TC Kimlik algoritma kontrol
data-type="kredikart"		//Kredi kartı algoritma kontrol
data-same="#parola"     	//parola id'sine sahip input ile aynı değeri taşımalı


$("#formalanı").submit(function() {
	FormValidate("#formadı");
});

$("#button").click(function() {
  FormValidate($("#divadı"));
});

*/

//CSS dosyasını ekle

function FormValidate2(area) {
    var ControlStatus = true;

    $(area + ' *[required]').each(function () {

        if ($(this).is(":visible") == true) { //kontrol gizli ise işlem yapma

            //data-error bilgisi (boşsa verilecek uyarı)
            var DataErrTxt;

            if ($(this).attr("type") == "checkbox") {//checkbox ise

                if ($(this).attr("data-error") == null) {
                    DataErrTxt = "Onay kutusunu işaretlemelisiniz!";
                } else {
                    DataErrTxt = $(this).attr("data-error");
                }

                if ($(this).parent(".formcontrolitemc").length <= 0) {
                    $(this).wrap('<div class="formcontrolitemc"></div>');
                }

                if (this.checked == true) {
                    $(this).parent(".formcontrolitemc").removeClass("errorinput");
                    $(this).parent(".formcontrolitemc").attr("title", "");
                } else {
                    $(this).parent(".formcontrolitemc").addClass("errorinput");
                    $(this).parent(".errorinput").attr("title", DataErrTxt);
                    ControlStatus = false;
                }

            } else if ($(this).attr("type") == "radio") { //radio seçim ise

                var OptName = $(this).attr("name");

                if ($(this).attr("data-error") == null) {
                    DataErrTxt = "Onay kutusunu işaretlemelisiniz!";
                } else {
                    DataErrTxt = $(this).attr("data-error");
                }

                if ($(this).parent(".formcontrolitemc").length <= 0) {
                    $(this).wrap('<div class="formcontrolitemc"></div>');
                }

                if ($('input[name = "' + OptName + '"').is(':checked')) {
                    $(this).parent(".formcontrolitemc").removeClass("errorinput");
                    $(this).parent(".formcontrolitemc").attr("title", "");
                } else {
                    $(this).parent(".formcontrolitemc").addClass("errorinput");
                    $(this).parent(".errorinput").attr("title", DataErrTxt);
                    ControlStatus = false;
                }
            } else if ($(this).prop("nodeName") == "SELECT") { //select ise
                //Ã–ğeler etrafına oluşturulmamışsa div oluştur
                if ($(this).parent(".formcontrolitem").length <= 0) {
                    $(this).wrap('<div class="formcontrolitem"></div>');
                }

                if ($(this).attr("data-error") == null) {
                    DataErrTxt = "Listeden seçim yapmalısınız!";
                } else {
                    DataErrTxt = $(this).attr("data-error");
                }

                if ($(this).val() == "0" || $(this).val() == "") {
                    $(this).parent(".formcontrolitem").addClass("errorinput");
                    $(this).parent(".formcontrolitem").removeClass("validinput");
                    $(this).parent(".errorinput").attr("title", DataErrTxt);
                    ControlStatus = false;
                } else {
                    $(this).parent(".formcontrolitem").removeClass("errorinput");
                    $(this).parent(".formcontrolitem").addClass("validinput");
                    $(this).parent(".formcontrolitem").attr("title", "");
                }

            } else {
                //Ã–ğeler etrafına oluşturulmamışsa div oluştur
                if ($(this).parent(".formcontrolitem").length <= 0) {
                    $(this).wrap('<div class="formcontrolitem"></div>');
                }

                if ($(this).val() == "") {

                    if ($(this).attr("data-error") == null) {
                        DataErrTxt = "Bu alan boş bırakılamaz!";
                    } else {
                        DataErrTxt = $(this).attr("data-error");
                    }

                    $(this).parent(".formcontrolitem").addClass("errorinput");
                    $(this).parent(".formcontrolitem").removeClass("validinput");
                    $(this).parent(".errorinput").attr("title", DataErrTxt);
                    ControlStatus = false;
                } else {
                    if ($(this).attr("type") == "email") {
                        if (!EMailVal($(this).val())) {

                            if ($(this).attr("data-error") == null) {
                                DataErrTxt = "Geçerli bir e-posta adresi yazın!";
                            } else {
                                DataErrTxt = $(this).attr("data-error");
                            }

                            $(this).parent(".formcontrolitem").addClass("errorinput");
                            $(this).parent(".formcontrolitem").removeClass("validinput");
                            $(this).parent(".errorinput").attr("title", DataErrTxt);
                            ControlStatus = false;
                        } else {
                            $(this).parent(".formcontrolitem").removeClass("errorinput"); 3
                            $(this).parent(".formcontrolitem").addClass("validinput");
                            $(this).parent(".formcontrolitem").attr("title", "");
                        }
                    } else {
                        $(this).parent(".formcontrolitem").removeClass("errorinput");
                        $(this).parent(".formcontrolitem").addClass("validinput");
                    }

                    if ($(this).attr("data-same")) {
                        var DataSame = $(this).attr("data-same");
                        if ($(this).val() == $(DataSame).val()) {
                            $(this).parent(".formcontrolitem").removeClass("errorinput");
                            $(this).parent(".formcontrolitem").addClass("validinput");
                        } else {
                            if ($(this).attr("data-error") == null) {
                                DataErrTxt = "Yazdığınız parolalar aynı olmalı!";
                            } else {
                                DataErrTxt = $(this).attr("data-error");
                            }
                            $(this).parent(".formcontrolitem").addClass("errorinput");
                            $(this).parent(".formcontrolitem").removeClass("validinput");
                            $(this).parent(".errorinput").attr("title", DataErrTxt);
                            ControlStatus = false;
                        }
                    }

                    if ($(this).attr("data-min") || $(this).attr("data-max")) {
                        var CharLenghtMin = $(this).attr("data-min");
                        var CharLenghtMax = $(this).attr("data-max");
                        if (CharLenghtMin == null) { CharLenghtMin = 0; }
                        if (CharLenghtMax == null) { CharLenghtMax = 2147483647; }

                        if ($(this).attr("data-error") == null) {
                            DataErrTxt = "Girdiğiniz karakter sayısı " + CharLenghtMin + " ile " + CharLenghtMax + " arasında olmalıdır!";
                        } else {
                            DataErrTxt = $(this).attr("data-error");
                        }

                        if ($(this).val().trim().length >= CharLenghtMin && $(this).val().trim().length <= CharLenghtMax) {
                            $(this).parent(".formcontrolitem").removeClass("errorinput");
                            $(this).parent(".formcontrolitem").addClass("validinput");
                        } else {
                            $(this).parent(".formcontrolitem").addClass("errorinput");
                            $(this).parent(".formcontrolitem").removeClass("validinput");
                            $(this).parent(".errorinput").attr("title", DataErrTxt);
                            ControlStatus = false;
                        }

                    }

                    if ($(this).attr("data-type") == "tckimlik") {
                        if (TCKimlikVal($(this).val()) == false) {

                            if ($(this).attr("data-error") == null) {
                                DataErrTxt = "Geçerli bir TC Kimlik numarası yazın!";
                            } else {
                                DataErrTxt = $(this).attr("data-error");
                            }

                            $(this).parent(".formcontrolitem").addClass("errorinput");
                            $(this).parent(".formcontrolitem").removeClass("validinput");
                            $(this).parent(".errorinput").attr("title", DataErrTxt);
                            ControlStatus = false;
                        } else {
                            $(this).parent(".formcontrolitem").removeClass("errorinput");
                            $(this).parent(".formcontrolitem").addClass("validinput");
                            $(this).parent(".formcontrolitem").attr("title", "");
                        }
                    }

                    if ($(this).attr("data-type") == "kredikart") {
                        if (KrediKart($(this).val()) == false) {

                            if ($(this).attr("data-error") == null) {
                                DataErrTxt = "Geçerli bir kredi kartı numarası yazın!";
                            } else {
                                DataErrTxt = $(this).attr("data-error");
                            }

                            $(this).parent(".formcontrolitem").addClass("errorinput");
                            $(this).parent(".formcontrolitem").removeClass("validinput");
                            $(this).parent(".errorinput").attr("title", DataErrTxt);
                            ControlStatus = false;
                        } else {
                            $(this).parent(".formcontrolitem").removeClass("errorinput");
                            $(this).parent(".formcontrolitem").addClass("validinput");
                            $(this).parent(".formcontrolitem").attr("title", "");
                        }
                    }
                }
            }
        }
    });

    if (ControlStatus == true) {
        console.log("Form doğrulandı");
        return "OK";
    } else {
        console.log("Form eksik");
        event.preventDefault();
        return false;
    }
}
function FormValidate3(area) {
    var ControlStatus = true;

    $(area + ' *[myvalidation]').each(function () {

        if ($(this).is(":visible") == true) { //kontrol gizli ise işlem yapma

            //data-error bilgisi (boşsa verilecek uyarı)
            var DataErrTxt;

            if ($(this).attr("type") == "checkbox") {//checkbox ise

                if ($(this).attr("data-error") == null) {
                    DataErrTxt = "Onay kutusunu işaretlemelisiniz!";
                } else {
                    DataErrTxt = $(this).attr("data-error");
                }

                if ($(this).parent(".formcontrolitemc").length <= 0) {
                    $(this).wrap('<div class="formcontrolitemc"></div>');
                }

                if (this.checked == true) {
                    $(this).parent(".formcontrolitemc").removeClass("errorinput");
                    $(this).parent(".formcontrolitemc").attr("title", "");
                } else {
                    $(this).parent(".formcontrolitemc").addClass("errorinput");
                    $(this).parent(".errorinput").attr("title", DataErrTxt);
                    ControlStatus = false;
                }

            } else if ($(this).attr("type") == "radio") { //radio seçim ise

                var OptName = $(this).attr("name");

                if ($(this).attr("data-error") == null) {
                    DataErrTxt = "Onay kutusunu işaretlemelisiniz!";
                } else {
                    DataErrTxt = $(this).attr("data-error");
                }

                if ($(this).parent(".formcontrolitemc").length <= 0) {
                    $(this).wrap('<div class="formcontrolitemc"></div>');
                }

                if ($('input[name = "' + OptName + '"').is(':checked')) {
                    $(this).parent(".formcontrolitemc").removeClass("errorinput");
                    $(this).parent(".formcontrolitemc").attr("title", "");
                } else {
                    $(this).parent(".formcontrolitemc").addClass("errorinput");
                    $(this).parent(".errorinput").attr("title", DataErrTxt);
                    ControlStatus = false;
                }
            } else if ($(this).prop("nodeName") == "SELECT") { //select ise
                //Ã–ğeler etrafına oluşturulmamışsa div oluştur
                if ($(this).parent(".formcontrolitem").length <= 0) {
                    $(this).wrap('<div class="formcontrolitem"></div>');
                }

                if ($(this).attr("data-error") == null) {
                    DataErrTxt = "Listeden seçim yapmalısınız!";
                } else {
                    DataErrTxt = $(this).attr("data-error");
                }

                if ($(this).val() == "0" || $(this).val() == "") {
                    $(this).parent(".formcontrolitem").addClass("errorinput");
                    $(this).parent(".formcontrolitem").removeClass("validinput");
                    $(this).parent(".errorinput").attr("title", DataErrTxt);
                    ControlStatus = false;
                } else {
                    $(this).parent(".formcontrolitem").removeClass("errorinput");
                    $(this).parent(".formcontrolitem").addClass("validinput");
                    $(this).parent(".formcontrolitem").attr("title", "");
                }

            } else {
                //Ã–ğeler etrafına oluşturulmamışsa div oluştur
                if ($(this).parent(".formcontrolitem").length <= 0) {
                    $(this).wrap('<div class="formcontrolitem"></div>');
                }

                if ($(this).val() == "") {

                    if ($(this).attr("data-error") == null) {
                        DataErrTxt = "Bu alan boş bırakılamaz!";
                    } else {
                        DataErrTxt = $(this).attr("data-error");
                    }

                    $(this).parent(".formcontrolitem").addClass("errorinput");
                    $(this).parent(".formcontrolitem").removeClass("validinput");
                    $(this).parent(".errorinput").attr("title", DataErrTxt);
                    ControlStatus = false;
                } else {
                    if ($(this).attr("type") == "email") {
                        if (!EMailVal($(this).val())) {

                            if ($(this).attr("data-error") == null) {
                                DataErrTxt = "Geçerli bir e-posta adresi yazın!";
                            } else {
                                DataErrTxt = $(this).attr("data-error");
                            }

                            $(this).parent(".formcontrolitem").addClass("errorinput");
                            $(this).parent(".formcontrolitem").removeClass("validinput");
                            $(this).parent(".errorinput").attr("title", DataErrTxt);
                            ControlStatus = false;
                        } else {
                            $(this).parent(".formcontrolitem").removeClass("errorinput"); 3
                            $(this).parent(".formcontrolitem").addClass("validinput");
                            $(this).parent(".formcontrolitem").attr("title", "");
                        }
                    } else {
                        $(this).parent(".formcontrolitem").removeClass("errorinput");
                        $(this).parent(".formcontrolitem").addClass("validinput");
                    }

                    if ($(this).attr("data-same")) {
                        var DataSame = $(this).attr("data-same");
                        if ($(this).val() == $(DataSame).val()) {
                            $(this).parent(".formcontrolitem").removeClass("errorinput");
                            $(this).parent(".formcontrolitem").addClass("validinput");
                        } else {
                            if ($(this).attr("data-error") == null) {
                                DataErrTxt = "Yazdığınız parolalar aynı olmalı!";
                            } else {
                                DataErrTxt = $(this).attr("data-error");
                            }
                            $(this).parent(".formcontrolitem").addClass("errorinput");
                            $(this).parent(".formcontrolitem").removeClass("validinput");
                            $(this).parent(".errorinput").attr("title", DataErrTxt);
                            ControlStatus = false;
                        }
                    }

                    if ($(this).attr("data-min") || $(this).attr("data-max")) {
                        var CharLenghtMin = $(this).attr("data-min");
                        var CharLenghtMax = $(this).attr("data-max");
                        if (CharLenghtMin == null) { CharLenghtMin = 0; }
                        if (CharLenghtMax == null) { CharLenghtMax = 2147483647; }

                        if ($(this).attr("data-error") == null) {
                            DataErrTxt = "Girdiğiniz karakter sayısı " + CharLenghtMin + " ile " + CharLenghtMax + " arasında olmalıdır!";
                        } else {
                            DataErrTxt = $(this).attr("data-error");
                        }

                        if ($(this).val().trim().length >= CharLenghtMin && $(this).val().trim().length <= CharLenghtMax) {
                            $(this).parent(".formcontrolitem").removeClass("errorinput");
                            $(this).parent(".formcontrolitem").addClass("validinput");
                        } else {
                            $(this).parent(".formcontrolitem").addClass("errorinput");
                            $(this).parent(".formcontrolitem").removeClass("validinput");
                            $(this).parent(".errorinput").attr("title", DataErrTxt);
                            ControlStatus = false;
                        }

                    }

                    if ($(this).attr("data-type") == "tckimlik") {
                        if (TCKimlikVal($(this).val()) == false) {

                            if ($(this).attr("data-error") == null) {
                                DataErrTxt = "Geçerli bir TC Kimlik numarası yazın!";
                            } else {
                                DataErrTxt = $(this).attr("data-error");
                            }

                            $(this).parent(".formcontrolitem").addClass("errorinput");
                            $(this).parent(".formcontrolitem").removeClass("validinput");
                            $(this).parent(".errorinput").attr("title", DataErrTxt);
                            ControlStatus = false;
                        } else {
                            $(this).parent(".formcontrolitem").removeClass("errorinput");
                            $(this).parent(".formcontrolitem").addClass("validinput");
                            $(this).parent(".formcontrolitem").attr("title", "");
                        }
                    }

                    if ($(this).attr("data-type") == "kredikart") {
                        if (KrediKart($(this).val()) == false) {

                            if ($(this).attr("data-error") == null) {
                                DataErrTxt = "Geçerli bir kredi kartı numarası yazın!";
                            } else {
                                DataErrTxt = $(this).attr("data-error");
                            }

                            $(this).parent(".formcontrolitem").addClass("errorinput");
                            $(this).parent(".formcontrolitem").removeClass("validinput");
                            $(this).parent(".errorinput").attr("title", DataErrTxt);
                            ControlStatus = false;
                        } else {
                            $(this).parent(".formcontrolitem").removeClass("errorinput");
                            $(this).parent(".formcontrolitem").addClass("validinput");
                            $(this).parent(".formcontrolitem").attr("title", "");
                        }
                    }
                }
            }
        }
    });

    if (ControlStatus == true) {
        console.log("Form doğrulandı");
        return "OK";
    } else {
        console.log("Form eksik");
        event.preventDefault();
        return false;
    }
}

function EMailVal(emailAddress) {
    var pattern = /^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([ \t]*\r\n)?[ \t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([ \t]*\r\n)?[ \t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i;
    return pattern.test(emailAddress);
}

function TCKimlikVal(a) {
    if (a.substr(0, 1) == 0 || a.length != 11) {
        return false;
    }
    var i = 9, md = '', mc = '', digit, mr = '';
    while (digit = a.charAt(--i)) {
        i % 2 == 0 ? md += digit : mc += digit;
    }
    if (((eval(md.split('').join('+')) * 7) - eval(mc.split('').join('+'))) % 10 != parseInt(a.substr(9, 1), 10)) {
        return false;
    }
    for (c = 0; c <= 9; c++) {
        mr += a.charAt(c);
    }
    if (eval(mr.split('').join('+')) % 10 != parseInt(a.substr(10, 1), 10)) {
        return false;
    }
    return true;
}

function KrediKart(number) {
    var regex = new RegExp("^[0-9]{16}$");
    if (!regex.test(number)) return false;

    var sum = 0;
    for (var i = 0; i < number.length; i++) {
        var intVal = parseInt(number.substr(i, 1));
        if (i % 2 == 0) {
            intVal *= 2;
            if (intVal > 9) {
                intVal = 1 + (intVal % 10);
            }
        }
        sum += intVal;
    }
    return (sum % 10) == 0;
}