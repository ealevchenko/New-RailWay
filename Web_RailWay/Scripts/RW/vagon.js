﻿$(function () {
    //-----------------------------------------------------------------------------------------
    // Объявление глобальных переменных
    //-----------------------------------------------------------------------------------------
    allVars = $.getUrlVars();   // Получить параметры get запроса
    var lang = $.cookie('lang'),
        resurses = {
            list: null,
            initObject: function (file, callback) {
                initLang(file, function (json) {
                    resurses.list = json;
                    if (typeof callback === 'function') {
                        callback(json);
                    }
                })
            },
            getText: function (tag) {
                var result = null;
                var str = getObjects(resurses.list, 'tag', tag);
                if (str != null) {
                    result = lang == 'en' ? str[0].en : str[0].ru;
                }
                return result;
            }
        },
        svagon = $("#vagon").spinner({
            spin: function (event, ui) {
                if (ui.value > 99999999) {
                    $(this).spinner("value", 1);
                    return false;
                } else if (ui.value < 1) {
                    $(this).spinner("value", 99999999);
                    return false;
                }
            }
        }),
        bt_searsh = $('#search').button({
            icon: "ui-icon-search"
        }).on('click', function (evt) {
            evt.preventDefault();
            table_history_car.viewTable(true);
            //table_history_arrival.viewTable(true);
            table_history_arrival.mtArrivalCar("viewCar", svagon.spinner("value"));
        }),
        // загрузка библиотек
        // Страны СНГ
        rw_reference_states = null,
        rw_reference_result = null,
        loadReference = function (callback) {
            var count = 2;
            // Загрузка библиотеки результатов  (metallurgtrans.js)
            getReferenceArrivalResult(function (result) {
                rw_reference_result = result;
                count -= 1;
                if (count <= 0) {
                    if (typeof callback === 'function') {
                        callback();
                    }
                }
            })
            // Загрузка библиотеки Справочник стран СНГ  (reference.js)
            getReferenceStates(function (result) {
                rw_reference_states = result;
                count -= 1;
                if (count <= 0) {
                    if (typeof callback === 'function') {
                        callback();
                    }
                }
            })
        },
        //


        rw_reference_country = {
            list: [],
            initObject: function () {
                getAsyncReferenceCountry(function (result)
                { rw_reference_country.list = result; });
            },
            getCountry: function (id) {
                var country = getObjects(this.list, 'id', id)
                if (country != null && country.length > 0) {
                    return country[0];
                }
            },
        },
        //
        rw_reference_cargo = {
            list: [],
            initObject: function () {
                getAsyncReferenceCargo(function (result)
                { rw_reference_cargo.list = result; });
            },
            getCargo: function (id) {
                var cargo = getObjects(this.list, 'id', id)
                if (cargo != null && cargo.length > 0) {
                    return cargo[0];
                }
            },
        },
        //
        rw_reference_consignee = {
            list: [],
            initObject: function () {
                getAsyncReferenceConsignee(function (result)
                { rw_reference_consignee.list = result; });
            },
            getConsignee: function (id) {
                var consignee = getObjects(this.list, 'id', id)
                if (consignee != null && consignee.length > 0) {
                    return consignee[0];
                }
            },
        },
        //
        rw_reference_station = {
            list: [],
            initObject: function () {
                getAsyncReferenceStation(function (result)
                { rw_reference_station.list = result; });
            },
            getStation: function (id) {
                var station = getObjects(this.list, 'id', id)
                if (station != null && station.length > 0) {
                    return station[0];
                }
            },
        },
        // Тупики
        rw_deadlock = {
            list: [],
            initObject: function () {
                getAsyncDeadlock(function (result)
                { rw_deadlock.list = result; });
            },
            getDeadlock: function (id) {
                var deadlock = getObjects(this.list, 'id', id)
                if (deadlock != null && deadlock.length > 0) {
                    return deadlock[0];
                }
            },
        },


        //rw_reference_states = {
        //    list: [],
        //    initObject: function () {
        //        getAsyncStates(function (result)
        //        { rw_reference_states.list = result; });
        //    },
        //    getStates: function (id) {
        //        var states = getObjects(this.list, 'id', id)
        //        if (states != null && states.length > 0) {
        //            return states[0];
        //        }
        //    },
        //},


        // Типы отчетов
        tab_type_vagons = {
            html_div: $("#tabs-report-vagons"),
            active: 0,
            initObject: function () {
                $('#link-tabs-history').text(resurses.getText("link_tabs_history"));
                $('#link-tabs-info').text(resurses.getText("link_tabs_info"));
                this.html_div.tabs({
                    collapsible: true,
                    activate: function (event, ui) {
                        tab_type_vagons.active = tab_type_vagons.html_div.tabs("option", "active");
                        //tab_type_vagons.activeTable(tab_type_vagons.active, false);
                    },
                });
                //this.activeTable(this.active, true);
            },
            activeTable: function (active, data_refresh) {
                //if (active == 0) {
                //    table_arrival.viewTable(data_refresh);
                //}
                //if (active == 1) {
                //    table_sending.viewTable(data_refresh);
                //}
                //if (active == 2) {
                //    //table_wt_routes.viewTable(table_wt_routes.view, data_refresh);
                //}
                //if (active == 3) {
                //    //table_wt_last.viewTable(data_refresh);
                //}
            }
        },
        //
        accordion_history = {
            html_history_car: $("#accordion-history-car"),
            html_history_sap: $("#accordion-history-sap"),
            html_history_arrival: $("#accordion-history-arrival"),
            icons: {
                header: "ui-icon-circle-arrow-e",
                activeHeader: "ui-icon-circle-arrow-s"
            },
            initObject: function () {
                this.html_history_car.accordion({
                    icons: this.icons,
                    heightStyle: "content",
                    collapsible: true,
                    activate: function (event, ui) {
                        var active = accordion_history.html_history_car.accordion("option", "active");
                        if (active === 0) {
                            //table_vagon.viewTableVagon(false);
                        }
                    }
                });
                this.html_history_sap.accordion({
                    icons: this.icons,
                    heightStyle: "content",
                    collapsible: true,
                    activate: function (event, ui) {
                        var active = accordion_history.html_history_car.accordion("option", "active");
                        if (active === 0) {
                            //table_vagon.viewTableVagon(false);
                        }
                    }
                });
                this.html_history_arrival.accordion({
                    icons: this.icons,
                    heightStyle: "content",
                    collapsible: true,
                    activate: function (event, ui) {
                        var active = accordion_history.html_history_arrival.accordion("option", "active");
                        if (active === 0) {
                            //table_vagon.viewTableNatHist(false);
                        }
                    }
                });
            }
        },
        //table-list-history-car
        table_history_car = {
            html_table: $('#table-list-history-car'),
            obj_table: null,
            obj: null,
            list: [],
            // Инициализировать таблицу
            initObject: function () {
                this.obj = this.html_table.DataTable({
                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                    "paging": true,
                    "ordering": true,
                    "info": false,
                    //"select": false,
                    //"filter": true,
                    //"scrollY": "600px",
                    //"scrollX": true,
                    language: {
                        emptyTable: resurses.getText("table_message_emptyTable"),
                        decimal: resurses.getText("table_decimal"),
                        search: resurses.getText("table_message_search"),
                    },
                    jQueryUI: true,
                    "createdRow": function (row, data, index) {
                        $(row).attr('id', data.id);
                        var bt_delete = $('<button id=' + data.id + ' class="ui-button ui-widget ui-corner-all" name="close"><span class="ui-icon ui-icon-closethick"></span>' + (lang == 'en' ? 'Delete' : 'Удалить') + '</button>');
                        var bt_correct = $('<button id=' + data.id + ' class="ui-button ui-widget ui-corner-all" name="close"><span class="ui-icon ui-icon-pencil"></span>' + (lang == 'en' ? 'Correction' : 'Коррекция') + '</button>');

                        $('td', row).eq(16).append(bt_delete).append(bt_correct);
                        bt_delete.on('click', function (evt) {
                            evt.preventDefault();
                            var id = $(this).attr("id")
                            confirm_delete_panel.Open(id);
                        });

                    },
                    columns: [
                        {
                            className: 'details-control',
                            orderable: false,
                            data: null,
                            defaultContent: '',
                            searchable: false, width: "30px"
                        },
                        { data: "position", title: resurses.getText("table_field_position"), width: "50px", orderable: true, searchable: false },
                        { data: "num", title: resurses.getText("table_field_num"), width: "50px", orderable: false, searchable: false },
                        { data: "id_sostav", title: resurses.getText("table_field_id_sostav"), width: "50px", orderable: false, searchable: true },
                        { data: "id_arrival", title: resurses.getText("table_field_id_arrival"), width: "50px", orderable: false, searchable: true },
                        { data: "dt_uz", title: resurses.getText("table_field_dt_uz"), width: "150px", orderable: true, searchable: true },
                        { data: "dt_inp_amkr", title: resurses.getText("table_field_dt_inp_amkr"), width: "150px", orderable: true, searchable: true },
                        { data: "natur_kis", title: resurses.getText("table_field_natur_kis"), width: "50px", orderable: false, searchable: true },
                        { data: "dt_out_amkr", title: resurses.getText("table_field_dt_out_amkr"), width: "150px", orderable: true, searchable: true },
                        { data: "natur_kis_out", title: resurses.getText("table_field_natur_kis_out"), width: "50px", orderable: true, searchable: true },
                        { data: "natur", title: resurses.getText("table_field_natur"), width: "50px", orderable: false, searchable: true },
                        { data: "dt_create", title: resurses.getText("table_field_dt_create"), width: "150px", orderable: true, searchable: true },
                        { data: "user_create", title: resurses.getText("table_field_user_create"), width: "150px", orderable: false, searchable: true },
                        { data: "dt_close", title: resurses.getText("table_field_dt_close"), width: "150px", orderable: true, searchable: true },
                        { data: "user_close", title: resurses.getText("table_field_user_close"), width: "150px", orderable: false, searchable: true },
                        { data: "parent_id", title: resurses.getText("table_field_parent_id"), width: "50px", orderable: false, searchable: true },
                        { data: null, defaultContent: '', width: "50px", orderable: false, searchable: false },
                    ],
                });
                this.obj_table = $('DIV#table-list-history-car_wrapper');
                //panel_table_arrival.initPanel(this.obj_table);
                this.initEventSelect();
                this.obj.order([1, 'desc']);
                //this.initEventSelectChild();
                //this.obj.columns([10, 11, 12]).visible(false, true);
            },
            // Показать таблицу с данными
            viewTable: function (data_refresh) {
                OnBegin();
                if (this.list == null | data_refresh == true) {
                    // Обновим данные
                    getAsyncHistoryCarsOfNum(
                        svagon.spinner("value"),
                        function (result) {
                            table_history_car.list = result;
                            table_history_car.loadDataTable(result);
                            table_history_car.obj.draw();
                        }
                    );
                } else {
                    table_history_car.loadDataTable(this.list);
                    table_history_car.obj.draw();
                };
            },
            // Загрузить данные
            loadDataTable: function (data) {
                this.list = data;
                this.obj.clear();
                for (i = 0; i < data.length; i++) {
                    this.obj.row.add({
                        "id": data[i].id,
                        "id_sostav": data[i].id_sostav,
                        "id_arrival": data[i].id_arrival,
                        "num": data[i].num,
                        "dt_uz": data[i].dt_uz,
                        "dt_inp_amkr": data[i].dt_inp_amkr,
                        "dt_out_amkr": data[i].dt_out_amkr,
                        "natur_kis": data[i].natur_kis,
                        "natur_kis_out": data[i].natur_kis_out,
                        "natur": data[i].natur,
                        "dt_create": data[i].dt_create,
                        "user_create": data[i].user_create,
                        "dt_close": data[i].dt_close,
                        "user_close": data[i].user_close,
                        "parent_id": data[i].parent_id,
                        "position": data[i].position,
                    });
                }
                LockScreenOff();
            },
            // Инициализация события выбора поля
            initEventSelect: function () {
                this.html_table.find('tbody')
                    .on('click', 'tr', function () {
                        var id = $(this).attr('id');
                        table_history_car.clearSelect();
                        $(this).addClass('selected');
                        table_history_car.viewTableCarsInpDelivery(id);
                        table_history_car.viewTableCarsOutDelivery(id);
                    });
            },
            // Сбросить выбор поля
            clearSelect: function () {
                this.html_table.find('tbody tr').removeClass('selected');
            },
            // Инициализация события детально
            initEventSelectChild: function () {
                this.html_table.find('tbody')
                    .on('click', 'td.details-control', function () {
                        var tr = $(this).closest('tr');
                        var row = table_arrival.obj.row(tr);
                        if (row.child.isShown()) {
                            // This row is already open - close it
                            row.child.hide();
                            tr.removeClass('shown');
                        }
                        else {
                            //row.child($('<tr id="detali-transfer"><td colspan="10"><div id="detali' + row.data().id + '" class="detali-operation"></div></td></tr>')).show();
                            row.child('<div id="detali-transfer' + row.data().id + '" class="detali-operation"> ' +
                                '<div id="tabs-detali' + row.data().id + '"> ' +
                                '<ul> ' +
                                '<li><a href="#tabs-detali' + row.data().id + '-1" id="link-tabs-detali' + row.data().id + '-1"></a></li> ' +
                                '<li><a href="#tabs-detali' + row.data().id + '-2" id="link-tabs-detali' + row.data().id + '-2"></a></li> ' +
                                '</ul> ' +
                                '<div id="tabs-detali' + row.data().id + '-1"> ' +
                                //'<table class="display compact" id="table-detali-full" style="width:100%" cellpadding="0"></table> ' +
                                '</div> ' +
                                '<div id="tabs-detali' + row.data().id + '-2"> ' +
                                //'<table class="display compact" id="table-detali-vagon" style="width:100%" cellpadding="0"></table> ' +
                                '</div> ' +
                                '</div> ' +
                                '</div>').show();
                            // Инициализируем
                            $('#link-tabs-detali' + row.data().id + '-1').text(resurses.getText("link_tabs_transfer_detali_1"));
                            $('#link-tabs-detali' + row.data().id + '-2').text(resurses.getText("link_tabs_transfer_detali_2"));
                            $('#tabs-detali' + row.data().id).tabs({
                                collapsible: true,
                            });
                            table_arrival.viewTableChildAllFields(row.data());
                            table_arrival.viewTableChildStatus(row.data());
                            tr.addClass('shown');
                        }
                    });
            },
            // Создать таблицу TableCarsInpDelivery
            viewTableCarsInpDelivery: function (id) {
                OnBegin();
                var target = $("#history-car-sap-inp");
                target.empty();
                target.append(resurses.getText("table_not_data"));
                // Обновим данные
                getAsyncCarsInpDeliveryOfCar(
                    id,
                    function (result) {
                        target.empty();
                        target.append(table_history_car.createTableCarsInpDelivery(result));
                        LockScreenOff();
                    }
                );

            },
            // Сформировать таблицу все поля
            createTableCarsInpDelivery: function (data) {
                if (data == null || data.length == 0) {
                    return resurses.getText("table_not_data")
                }
                var country = rw_reference_country.getCountry(data.id_country);
                var cargo = rw_reference_cargo.getCargo(data.id_cargo);
                var consignee = rw_reference_consignee.getConsignee(data.id_consignee);

                var list_tr = '<tbody>' +
                    '<tr><th>' + resurses.getText("table_field_datetime") + '</th>' + '<td>' + data.datetime + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_composition_index") + '</th>' + '<td>' + data.composition_index + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_id_arrival") + '</th>' + '<td>' + data.id_arrival + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_position") + '</th>' + '<td>' + data.position + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_num_nakl_sap") + '</th>' + '<td>' + data.num_nakl_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_country") + '</th>' + '<td>' + '(' + data.country_code + ')' + (country != null ? (lang == 'en' ? country.country_en : country.country_ru) : '?') + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_weight_cargo") + '</th>' + '<td>' + data.weight_cargo + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_num_doc_reweighing_sap") + '</th>' + '<td>' + data.num_doc_reweighing_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_dt_doc_reweighing_sap") + '</th>' + '<td>' + data.dt_doc_reweighing_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_weight_reweighing_sap") + '</th>' + '<td>' + data.weight_reweighing_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_dt_reweighing_sap") + '</th>' + '<td>' + data.dt_reweighing_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_post_reweighing_sap") + '</th>' + '<td>' + data.post_reweighing_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_cargo") + '</th>' + '<td>' + '(' + data.cargo_code + ')' + (cargo != null ? (lang == 'en' ? cargo.name_full_en : cargo.name_full_ru) : '?') + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_sap_material") + '</th>' + '<td>' + '(' + data.material_code_sap + ')' + data.material_name_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_station_shipment") + '</th>' + '<td>' + data.station_shipment + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_sap_shipment") + '</th>' + '<td>' + '(' + data.station_shipment_code_sap + ')' + data.station_shipment_name_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_consignee") + '</th>' + '<td>' + '(' + data.consignee + ')' + (consignee != null ? (lang == 'en' ? consignee.name_full_en : consignee.name_full_ru) : '?') + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_shop") + '</th>' + '<td>' + '(' + data.shop_code_sap + ')' + data.shop_name_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_new_shop") + '</th>' + '<td>' + '(' + data.new_shop_code_sap + ')' + data.new_shop_name_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_permission_unload_sap") + '</th>' + '<td>' + data.permission_unload_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_step1_sap") + '</th>' + '<td>' + data.step1_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_step2_sap") + '</th>' + '<td>' + data.step2_sap + '</td></tr>' +
                    '</tbody>';
                return '<table class="table-striped table-bordered" id="table-list-history-car-sap-inp" cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' + list_tr + '</table>';
            },
            // Создать таблицу TableCarsOutDelivery
            viewTableCarsOutDelivery: function (id) {
                OnBegin();
                var target = $("#history-car-sap-out");
                target.empty();
                target.append(resurses.getText("table_not_data"));
                // Обновим данные
                getAsyncCarsOutDeliveryOfCar(
                    id,
                    function (result) {
                        target.empty();
                        target.append(table_history_car.createTableCarsOutDelivery(result));
                        LockScreenOff();
                    }
                );

            },
            // Сформировать таблицу все поля
            createTableCarsOutDelivery: function (data) {
                if (data == null || data.length == 0) {
                    return resurses.getText("table_not_data")
                }
                var country = rw_reference_country.getCountry(data.id_country_out);
                var cargo = rw_reference_cargo.getCargo(data.id_cargo);
                var station = rw_reference_station.getStation(data.id_station_out);
                var deadlock = rw_deadlock.getDeadlock(data.id_tupik);
                var list_tr = '<tbody>' +
                    '<tr><th>' + resurses.getText("table_field_num_nakl_sap") + '</th>' + '<td>' + data.num_nakl_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_deadlock") + '</th>' + '<td>' + (deadlock != null ? deadlock.name : '') + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_country_out") + '</th>' + '<td>' + (country != null ? (lang == 'en' ? country.country_en : country.country_ru) : '?') + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_station_out") + '</th>' + '<td>' + (station != null ? station.name : '') + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_note") + '</th>' + '<td>' + data.note + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_cargo") + '</th>' + '<td>' + '(' + data.cargo_code + ')' + (cargo != null ? (lang == 'en' ? cargo.name_full_en : cargo.name_full_ru) : '?') + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_weight_cargo") + '</th>' + '<td>' + data.weight_cargo + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_num_doc_reweighing_sap") + '</th>' + '<td>' + data.num_doc_reweighing_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_dt_doc_reweighing_sap") + '</th>' + '<td>' + data.dt_doc_reweighing_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_weight_reweighing_sap") + '</th>' + '<td>' + data.weight_reweighing_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_dt_reweighing_sap") + '</th>' + '<td>' + data.dt_reweighing_sap + '</td></tr>' +
                    '<tr><th>' + resurses.getText("table_field_post_reweighing_sap") + '</th>' + '<td>' + data.post_reweighing_sap + '</td></tr>' +
                    '</tbody>';
                return '<table class="table-striped table-bordered" id="table-list-history-car-sap-out" cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' + list_tr + '</table>';
            },


            //createTableStatus: function (data, id) {
            //    if (data == null || data.length == 0) {
            //        return resurses.getText("table_not_data")
            //    }
            //    var list_tr = '<thead><tr>' +
            //        '<th>' + resurses.getText("table_field_num_car") + '</th>' +
            //        '<th>' + resurses.getText("table_field_reult_set_car") + '</th>' +
            //        '<th>' + resurses.getText("table_field_reult_upd_car") + '</th>' +
            //        '</tr></thead>';
            //    list_tr += '<tbody>';
            //    for (i = 0; i < data.length; i++) {
            //        list_tr += '<tr>' +
            //            //'<td>' + data[i].car + '</td>' +
            //            '<td><a id=' + data[i].car + ' name="natur" href="#">' + data[i].car + '</a></td>' +
            //            '<td class="' + data[i].car_set + '">' + data[i].car_set + '</td>' +
            //            '<td class="' + data[i].car_upd + '">' + data[i].car_upderr + '</td>' +
            //            '</tr>';
            //    }
            //    list_tr += '</tbody>';
            //    return '<table class="table-transfer-detali" id="table-detali-status-' + id + '" cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' + list_tr + '</table>';
            //},
            //// Показать все поля
            //viewTableChildAllFields: function (data) {
            //    var target = $("#tabs-detali" + data.id + "-1");
            //    target.empty();
            //    var tab = this.createTableAllFields(data);
            //    target.append(tab);
            //},

            //// Добавить значения количества вагонов по таблице Prom.Vagon
            //viewFieldClose: function (data) {
            //    if (data.close != null) {
            //        var row = table_arrival.obj.row('#' + data.id).index();
            //        table_arrival.obj.cell(row, 9).data(data.close_user + " (" + data.close + ")" + (data.close_comment != null ? " - <span>" + data.close_comment + "</span>" : "")).draw();
            //    }
            //},

        },
        // Таблица история прибытия вагоно
        table_history_arrival = null,

        //table_history_arrival = {
        //    html_table: $('#table-list-history-arrival'),
        //    html_div_panel: $('<div class="dt-buttons setup-operation" id="property"></div>'),
        //    html_div_panel_select: $('<div class="setup-operation" id="view-select"></div>'),
        //    // Выбор отображения 
        //    label_view_first: $('<label for="view-first-operation"></label>'),
        //    radio_view_first: $('<input type="radio" name="mode" id="view-first-operation">'),
        //    label_view_last: $('<label for="view-last-operation"></label>'),
        //    radio_view_last: $('<input type="radio" name="mode" id="view-last-operation" checked="checked" >'),
        //    obj_table: null,
        //    obj: null,
        //    list: [],
        //    list_history_car: [],
        //    type_history: 1,        // отображать пребытие на станцию - 0 или отпраку со станции -1
        //    type_load: 0,           // загрузить справочники сразу - 0 или запрос производить по id - 1
        //    reference_states: [],   // справочник список стран
        //    reference_result: [],   // справочник результатов
        //    // Инициализация панели
        //    initPanel: function () {
        //        // Настроим панель info
        //        this.html_div_panel_select
        //            .append(this.label_view_first.text(resurses.getText("label_view_first")))
        //            .append(this.radio_view_first)
        //                .append(this.label_view_last.text(resurses.getText("label_view_last")))
        //            .append(this.radio_view_last)
        //        this.html_div_panel
        //            //.append(this.html_div_panel_info)
        //            .append(this.html_div_panel_select);
        //        this.obj_table.prepend(this.html_div_panel);
        //        this.html_div_panel_select.controlgroup();
        //        // определим событие выбора режима
        //        this.radio_view_first.on("change", this.selectViewOperation);
        //        this.radio_view_last.on("change", this.selectViewOperation);
        //    },
        //    // Определение события выбора отображения операции
        //    selectViewOperation: function (e) {
        //        var target = $(e.target);
        //        if (target.is("#view-first-operation")) {
        //            table_history_arrival.type_history = 0;
        //        }
        //        if (target.is("#view-last-operation")) {
        //            table_history_arrival.type_history = 1;
        //        }
        //        table_history_arrival.viewTable(false);
        //    },
        //    // Загрузка библиотек
        //    initReference: function (callback) {
        //        getReferenceArrivalResult(function (result) {
        //            table_history_arrival.reference_result = result;
        //        })
        //        // Справочник стран СНГ
        //        getReferenceStates(function (result) {
        //            table_history_arrival.reference_states = result;
        //            if (typeof callback === 'function') {
        //                callback();
        //            }
        //        }); 
        //    },
        //    // Инициализировать таблицы операции
        //    initTableListOperation: function (html_table, type) {
        //        return $(html_table).DataTable({
        //            "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
        //            "paging": type == 0 ? true : false,
        //            "ordering": true,
        //            "info": false,
        //            //"select": false,
        //            //"filter": true,
        //            //"scrollY": "600px",
        //            "scrollX": true,
        //            language: {
        //                emptyTable: resurses.getText("table_message_emptyTable"),
        //                decimal: resurses.getText("table_decimal"),
        //                search: resurses.getText("table_message_search"),
        //            },
        //            jQueryUI: true,
        //            "createdRow": function (row, data, index) {
        //                $(row).attr('id', type == 0 ? data.id_history : data.ID);
        //            },
        //            columns: [
        //                {
        //                    className: 'details-control',
        //                    orderable: false,
        //                    data: null,
        //                    defaultContent: '',
        //                    searchable: false,
        //                    width: "30px",
        //                    visible: type == 0 ? true : false
        //                },
        //                { data: "IDSostav", title: resurses.getText("table_field_id_sostav"), width: "50px", orderable: false, searchable: true },
        //                { data: "Num", title: resurses.getText("table_field_num"), width: "50px", orderable: false, searchable: false },
        //                { data: "CompositionIndex", title: resurses.getText("table_field_composition_index"), width: "100px", orderable: false, searchable: false },
        //                { data: "DateOperation", title: resurses.getText("table_field_date_operation"), width: "100px", orderable: false, searchable: false },
        //                { data: "Position", title: resurses.getText("table_field_position"), width: "50px", orderable: false, searchable: false },
        //                { data: "Operation", title: resurses.getText("table_field_operation"), width: "50px", orderable: false, searchable: false },
        //                { data: "Consignee", title: resurses.getText("table_field_consignee"), width: "50px", orderable: false, searchable: false },
        //                { data: "Cargo", title: resurses.getText("table_field_cargo"), width: "200px", orderable: false, searchable: false },
        //                { data: "StationEnd", title: resurses.getText("table_field_station_end"), width: "150px", orderable: false, searchable: false },
        //                { data: "Weight", title: resurses.getText("table_field_weight_cargo"), width: "50px", orderable: false, searchable: false },
        //                { data: "Country", title: resurses.getText("table_field_country"), width: "50px", orderable: false, searchable: false },
        //                { data: "TrainNumber", title: resurses.getText("table_field_train_number"), width: "50px", orderable: false, searchable: false },
        //                { data: "Arrival", title: resurses.getText("table_field_arrival_car"), width: "150px", orderable: false, searchable: false },
        //                { data: "NumDocArrival", title: resurses.getText("table_field_arrival_doc"), width: "150px", orderable: false, searchable: false },
        //                { data: "UserName", title: resurses.getText("table_field_user_name"), width: "150px", orderable: false, searchable: false },
        //            ],
        //        });
        //    },
        //    // Инициализировать весь объект
        //    initObject: function () {
        //        if (this.type_load == 0) {
        //            this.initReference(function () {
        //                // После загрузки библиотек инициализируем таблицу
        //                table_history_arrival.initObjectTable();
        //            });
        //        } else {
        //           table_history_arrival.initObjectTable();
        //        }

        //    },
        //    // Инициализировать таблицу
        //    initObjectTable: function () {
        //        this.obj = this.initTableListOperation(this.html_table, 0);
        //        this.obj_table = $('DIV#table-list-history-arrival_wrapper');
        //        this.initPanel();
        //        //this.initEventSelect();
        //        this.initEventSelectChild();
        //        this.obj.order([1, 'desc']);
        //    },
        //    // Показать таблицу с данными
        //    viewTable: function (data_refresh) {
        //        OnBegin();
        //        if (this.list_history_car == null | data_refresh == true) {
        //            // Обновим данные
        //            getAsyncArrivalCars(
        //                svagon.spinner("value"),
        //                function (result) {
        //                    table_history_arrival.list = result;
        //                    table_history_arrival.createHistory(result)
        //                    table_history_arrival.loadDataTable(table_history_arrival.list_history_car);
        //                    table_history_arrival.obj.draw();
        //                }
        //            );
        //        } else {
        //            table_history_arrival.loadDataTable(this.list_history_car);
        //            table_history_arrival.obj.draw();
        //        };
        //    },
        //    // Получить историю по вагону
        //    getHistory: function (obj, list, global_list) {
        //        list.push(obj);
        //        var first_arrival = getObjects(global_list, 'ParentID', obj.ID);
        //        if (first_arrival != null && first_arrival.length > 0) {
        //            table_history_arrival.getHistory(first_arrival[0], list, global_list);
        //        }
        //    },
        //    // Сформировать историю по вагону
        //    createHistory: function (data) {
        //        // Сбросим историю
        //        table_history_arrival.list_history_car = [];
        //        // Заполним новую
        //        var first_arrival = getObjects(data, 'ParentID', null);
        //        if (first_arrival != null && first_arrival.length > 0) {
        //            for (i = 0; i < first_arrival.length; i++) {
        //                var objects = [];
        //                table_history_arrival.getHistory(first_arrival[i], objects, data);
        //                table_history_arrival.list_history_car.push({ id: i + 1, first: first_arrival[i], last: objects[objects.length - 1], history: objects });
        //            }
        //        }
        //    },
        //    // Добавить строку операции
        //    addRow: function (obj, i, history, id_history) {

        //        if (this.type_load == 0) {
        //            // взять данные из внутреннего справочника
        //            var country = this.reference_states != null ? this.reference_states.getCountry(history.CountryCode) : null;
        //            var result = history.NumDocArrival<=0 ? this.reference_result != null ? this.reference_result.getResult(history.NumDocArrival).text + '('+history.NumDocArrival+')' : null : history.NumDocArrival;
        //        } else {
        //            // получить данные из сервера
        //            this.loadFieldCountry(obj, i, history.CountryCode);
        //            this.loadFieldResult(obj, i, history.NumDocArrival);
        //        }
        //        obj.row.add({
        //            "id_history": id_history,
        //            "ID": history.ID,
        //            "IDSostav": history.IDSostav,
        //            "Position": history.Position,
        //            "Num": history.Num,
        //            "Country": this.type_load == 0 ? country.state + '(' + history.CountryCode + ')' : history.CountryCode,
        //            //"Country": history.CountryCode,
        //            "CountryCode": history.CountryCode,
        //            "Weight": history.Weight,
        //            "CargoCode": history.CargoCode,
        //            //"Cargo": history.Cargo,
        //            "Cargo": history.Cargo + '(' + history.CargoCode + ')',
        //            "StationCode": history.StationCode,
        //            "Station": history.Station,
        //            "StationEnd": history.Station + '(' + history.StationCode + ')',
        //            "Consignee": history.Consignee,
        //            "Operation": history.Operation,
        //            "CompositionIndex": history.CompositionIndex,
        //            "DateOperation": history.DateOperation,
        //            "TrainNumber": history.TrainNumber,
        //            "NumDocArrival": this.type_load == 0 ? result : history.NumDocArrival,
        //            "Arrival": history.Arrival,
        //            "ParentID": history.ParentID,
        //            "UserName": history.UserName,
        //        });
        //    },
        //    // Загрузить данные
        //    loadDataTable: function (data) {
        //        this.obj.clear();

        //        for (i = 0; i < data.length; i++) {
        //            if (this.type_history == 0) {
        //                var history = data[i].first;
        //            };
        //            if (this.type_history == 1) {
        //                var history = data[i].last;
        //            };
        //            //var country = thisreference_states != null ? this.reference_states.getCountry(history.CountryCode) : null;
        //            this.addRow(this.obj, i, history, data[i].id);
        //        }
        //        LockScreenOff();
        //    },
        //    // Загрузить поле страна
        //    loadFieldCountry: function (obj, row, code) {
        //        getAsyncStatesOfID(code, function (result) {
        //            obj.cell(row, 11).data(result.state + '(' + code + ')').draw();
        //        });
        //    },
        //    // Загрузить поле страна
        //    loadFieldResult: function (obj, row, num) {
        //        getAsyncArrivalResult(num, function (result) {
        //            obj.cell(row, 14).data(result.text + '(' + result.value + ')').draw();
        //        });
        //    },
        //    // Инициализация события детально
        //    initEventSelectChild: function () {
        //        this.html_table.find('tbody')
        //            .on('click', 'td.details-control', function () {
        //                var tr = $(this).closest('tr');
        //                var row = table_history_arrival.obj.row(tr);
        //                if (row.child.isShown()) {
        //                    // This row is already open - close it
        //                    row.child.hide();
        //                    tr.removeClass('shown');
        //                }
        //                else {
        //                    row.child('<div id="detali-arrival-operation-' + row.data().id_history + '" class="detali-operation">' +
        //                        '<table class="table-cars cell-border" id="table-detali-arrival-operation-' + row.data().id_history + '" style="width:100%" cellpadding="0"></table>' +
        //                        '</div>').show();
        //                    // Инициализируем
        //                    table_history_arrival.viewTableChildOperation(row.data());
        //                    tr.addClass('shown');
        //                }
        //            });
        //    },
        //    // Показать таблицу детали операции
        //    viewTableChildOperation: function (data) {

        //        if ($.fn.dataTable.isDataTable('#table-detali-arrival-operation-' + data.id_history)) {
        //            detali_operation = $('#table-detali-arrival-operation-' + data.id_history).DataTable();
        //        }
        //        else {
        //            detali_operation = this.initTableListOperation('#table-detali-arrival-operation-' + data.id_history, 1);
        //            // Обновим данные
        //            var history_arrival = getObjects(this.list_history_car, 'id', data.id_history);
        //            if (history_arrival != null && history_arrival.length > 0) {
        //                detali_operation.clear();
        //                for (i = 0; i < history_arrival[0].history.length; i++) {
        //                    var history = history_arrival[0].history[i];
        //                    this.addRow(detali_operation, i, history, null);
        //                }
        //            }
        //        } // end else if
        //        detali_operation.draw();
        //    },
        //},
        // Панель подтверждения удаления
        confirm_delete_panel = {
            html_div: $("#delete-comment"),
            obj: null,
            id_delete: null,
            initObject: function () {
                this.obj = this.html_div.dialog({
                    resizable: false,
                    modal: true,
                    autoOpen: false,
                    height: "auto",
                    width: 300,
                    buttons: {
                        "Удалить": function () {
                            $(this).dialog("close");
                            confirm_delete_panel.Delete(confirm_delete_panel.id_delete);
                        },
                        Cancel: function () {
                            $(this).dialog("close");
                        }
                    }
                });
            },
            Open: function (id) {
                confirm_delete_panel.id_delete = id;
                $('#delete-comment').text(resurses.getText("label_delete_comment") + id);
                this.obj.dialog("option", "title", resurses.getText("confirm_delete_panel_form_text"));
                this.obj.dialog("open");
            },
            Delete: function (id) {
                deleteAsyncSaveCar(
                    id,
                    function (result) {
                        if (Number(result) < 0) {
                            alert(resurses.getText("message_error_delete_vagon") + data);
                        }
                        table_history_car.viewTable(true);
                    });
            }
        }
    //-----------------------------------------------------------------------------------------
    // Функции
    //-----------------------------------------------------------------------------------------
    var outVal = function (i) {
        return i != null ? Number(i) : '';
    };
    //-----------------------------------------------------------------------------------------
    // Инициализация объектов
    //-----------------------------------------------------------------------------------------
    resurses.initObject("/railway/Scripts/RW/rw.json",
        function () {
            // Загружаем дальше
            //$('#label-select-vagon').text(resurses.getText("label_select_vagon"));
            //bt_searsh.text(resurses.getText("button_to_searsh"));
            //$('#searsh').text(resurses.getText("button_to_searsh"));
            //$('#to-excel').text(resurses.getText("button_to_excel"));
            confirm_delete_panel.initObject();      // Панель подтверждения удаления

            rw_reference_country.initObject();      // Справочник стран
            rw_reference_cargo.initObject();        // Справочник грузов
            rw_reference_consignee.initObject();    // Справочник грузоотправителей
            rw_reference_station.initObject();      // Справочник станций
            //getReferenceStates(function (result) {
            //    rw_reference_states = result;
            //}); // Справочник стран СНГ

            // Загрузка библиотек
            loadReference(function (result) {
                table_history_arrival = $('#history-arrival').mtArrivalCar({
                    class_table: "compact table-cars cell-border",
                    default_sort_arrival: false,
                    detali: true,
                    reference_result: rw_reference_result,
                    reference_states: rw_reference_states,
                });
            })


            rw_deadlock.initObject();                // Справочник тупики

            table_history_car.initObject();

            accordion_history.initObject();

            tab_type_vagons.initObject(); // Типы закладок отчетов

            //var dd = allVars.length;
            if (allVars.num != null) {
                svagon.spinner("value", allVars.num);
                table_history_car.viewTable(true); // Первый запуск
                //table_history_arrival.viewTable(true); // Первый запуск
            } else {
                //!!!! тест
                svagon.spinner("value", 52921079)

            }


        }); // локализация



});