﻿//-------------------------------------------------------
// Для работы с модулем добавте файл common.js
//-------------------------------------------------------
// Получить название сервиса или список сервисов
function getServicesName(service) {
    var value = "?";  //значение по умолчанию умолчанию
    $.ajax({
        type: 'GET',
        url: service != null ? '/railway/api/log/service/name/' + service : '/railway/api/log/service/name',
        async: false,
        dataType: 'json',
        success: function (data) {
            value = data;
        }
    });
    return value;
}
// Получить тип переменной или список типов переменной
function getTypeValue(type) {
    var value = "?";  //значение по умолчанию умолчанию
    $.ajax({
        type: 'GET',
        url: type != null ? '/railway/api/setting/type_value/' + type : '/railway/api/setting/type_value',
        async: false,
        dataType: 'json',
        success: function (data) {
            value = data;
        }
    });
    return value;
}
function getSetting(correct, service) {
    var value = null;  //значение по умолчанию умолчанию
    var list_serv = getServicesName();
    var list_type = getTypeValue();
    $.ajax({
        url: service != null ? '/railway/api/setting/service/' + service : '/railway/api/setting',
        type: 'GET',
        async: false,
        dataType: 'json',
        success: function (jsondata) {
            if (correct) {
                var list_log = [];
                for (var i = 0; i < jsondata.length; i++) {
                    list_log.push({
                        ID: jsondata[i].IDSettings,
                        Key: jsondata[i].Key,
                        Value: jsondata[i].Value,
                        Description: jsondata[i].Description,
                        IDTypeValue: jsondata[i].IDTypeValue,
                        typevalue: getTextOption(list_type, jsondata[i].IDTypeValue != null ? jsondata[i].IDTypeValue : -1),
                        IDService: jsondata[i].IDService,
                        servicename: getTextOption(list_serv, jsondata[i].IDService != null ? jsondata[i].IDService : -1),
                    });
                }
            }
            value = list_log;
        },
        error: function (x, y, z) {
            OnAJAXError(x, y, z);
        }
    });
    return value;
}
