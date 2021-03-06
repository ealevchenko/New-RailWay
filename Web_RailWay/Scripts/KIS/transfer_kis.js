﻿$(function () {
    //-----------------------------------------------------------------------------------------
    // Объявление глобальных переменных
    //-----------------------------------------------------------------------------------------
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
        dt = new Date(),
        start = new Date(dt.getFullYear(), dt.getMonth(), dt.getDate() - 1, 00, 00, 00),
        stop = new Date(dt.getFullYear(), dt.getMonth(), dt.getDate(), 23, 59, 59),
        datetime_range = {
            html_range: $("#select-range"),
            obj: null,
            initObject: function () {
                this.obj = this.html_range.dateRangePicker(
                    {
                        startOfWeek: 'monday',
                        separator: resurses.getText("table_message_separator"),
                        language: lang,
                        format: resurses.getText("table_date_format"),
                        autoClose: false,
                        showShortcuts: false,
                        getValue: function () {
                            if ($('#date-start').val() && $('#date-stop').val())
                                return $('#date-start').val() + ' to ' + $('#date-stop').val();
                            else
                                return '';
                        },
                        setValue: function (s, s1, s2) {
                            $('#date-start').val(s1);
                            $('#date-stop').val(s2);
                        },
                        time: {
                            enabled: true
                        },
                    }).
                    bind('datepicker-change', function (evt, obj) {
                        start = obj.date1;
                        stop = obj.date2;
                    })
                    .bind('datepicker-closed', function () {
                        tab_type_transfer.activeTable(tab_type_transfer.active, true);
                    });
                var s_d_start = start.getDate() + '.' + (start.getMonth() + 1) + '.' + start.getFullYear() + ' ' + start.getHours() + ':' + start.getMinutes();
                var s_d_stop = stop.getDate() + '.' + (stop.getMonth() + 1) + '.' + stop.getFullYear() + ' ' + stop.getHours() + ':' + stop.getMinutes();
                datetime_range.obj.data('dateRangePicker').setDateRange(s_d_start, s_d_stop, true);
            }
        },
        // Типы отчетов
        tab_type_transfer = {
            html_div: $("#tabs-report-transfer"),
            active: 0,
            initObject: function () {
                $('#link-tabs-transfer-arrival').text(resurses.getText("link-tabs-transfer-arrival"));
                $('#link-tabs-transfer-sending').text(resurses.getText("link-tabs-transfer-sending"));
                $('#link-tabs-transfer-input').text(resurses.getText("link-tabs-transfer-input"));
                $('#link-tabs-transfer-output').text(resurses.getText("link-tabs-transfer-output"));
                this.html_div.tabs({
                    collapsible: true,
                    activate: function (event, ui) {
                        tab_type_transfer.active = tab_type_transfer.html_div.tabs("option", "active");
                        tab_type_transfer.activeTable(tab_type_transfer.active, false);
                    },
                });
                this.activeTable(this.active, true);
            },
            activeTable: function (active, data_refresh) {
                if (active == 0) {
                    table_arrival.viewTable(data_refresh);
                }
                if (active == 1) {
                    table_sending.viewTable(data_refresh);
                }
                if (active == 2) {
                    //table_wt_routes.viewTable(table_wt_routes.view, data_refresh);
                }
                if (active == 3) {
                    //table_wt_last.viewTable(data_refresh);
                }
            }

        },
        // список станций
        rw_stations = {
            list: [],
            initObject: function (callback) {
                getAsyncStations(function (result) {
                    rw_stations.list = result;
                    if (typeof callback === 'function') {
                        callback(result);
                    }
                });
            },
            selectStationKIS: function (id_kis) {
                var station = getObjects(this.list, 'id_kis', id_kis)
                if (station != null && station.length > 0) {
                    return station[0];
                }
            },
        },
        // список статусов
        rw_status = {
            list: null,
            initObject: function () {
                getAsyncStatus(null, function (result)
                { rw_status.list = result; });
            },
            selectStatusName: function (id) {
                var status = getObjects(this.list, 'value', id)
                if (status != null && status.length > 0) {
                    return status[0].text;
                }
            },
        },
        // Панель таблицы
        panel_table_arrival = {
            html_div_panel: $('<div class="dt-buttons setup-operation" id="property"></div>'),
            //html_div_panel_info: $('<div class="setup-operation" id="last-info"></div>'),
            html_div_panel_select: $('<div class="setup-operation" id="last-select"></div>'),

            label_last_total: $('<label class="label-text" for="label-last-total-value"></label>'),
            label_last_total_value: $('<label class="value-text" id="label-last-total-value"></label>'),

            button_close_detali: $('<button class="ui-button ui-widget ui-corner-all"></button>'),
            initPanel: function (obj) {
                // Настроим панель info
                //this.html_div_panel_info
                //.append(this.label_last_date)
                //.append(this.label_last_date_value)
                //.append(this.label_last_total.text(resurses.getText("label_total_cars")))
                //.append(this.label_last_total_value);

                this.html_div_panel_select
                    .append(this.button_close_detali.text(resurses.getText("button_close_detali")))

                this.html_div_panel
                    //.append(this.html_div_panel_info)
                    .append(this.html_div_panel_select);
                obj.prepend(this.html_div_panel);
                // Обработка события закрыть детали
                this.button_close_detali.on('click', function () {
                    var trs = $('tr.shown');

                    for (i = 0; i < trs.length; i++) {
                        var row = table_arrival.obj.row(trs[i]);
                        if (row.child.isShown()) {
                            // This row is already open - close it
                            row.child.hide();
                        }
                    }
                    $('tr').removeClass('shown');
                });
            },
        },
        // ТАБЛИЦА статуса переноса прибытия
        table_arrival = {
            html_table: $('#table-transfer-arrival'),
            obj_table: null,
            obj: null,
            list: null,
            start: null,
            stop: null,
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
                        $(row).attr('id', data.id).addClass(data.status);
                        // Ссылка на КИС по натурке
                        var link_kis = $('<a id=' + data.id + ' target="_blank" href="/railway/KIS/Home/Natur?natur=' + data.natur +
                            '&day=' + data.day +
                            '&month=' + data.month +
                            '&year=' + data.year +
                            '&hour=' + data.hour +
                            '&minute=' + data.minute +
                            '">' + data.natur + '</a>');
                        $('td', row).eq(1).html(link_kis);
                        // Поле закрытия
                        if (data.close == null) {
                            var bt = $('<button id=' + data.id + ' class="ui-button ui-widget ui-corner-all" name="close"><span class="ui-icon ui-icon-circle-close"></span>' + (lang == 'en' ? 'Close' : 'Закрыть') + '</button>');
                            $('td', row).eq(9).html(bt);
                            bt.on('click', function (evt) {
                                evt.preventDefault();
                                var id = $(this).attr("id")
                                confirm_close_panel.Open(id, 0);
                            });
                        };
                        if (data.cwagons == null || data.cwagons == 0 || data.cwagons != data.swagons) {
                            $('td', row).eq(6).addClass('error-count');
                        }
                        if (data.cnathist == null || data.cnathist == 0 || data.cnathist != data.snathist) {
                            $('td', row).eq(7).addClass('error-count');
                        }
                    },
                    columns: [
                        {
                            className: 'details-control',
                            orderable: false,
                            data: null,
                            defaultContent: '',
                            searchable: false, width: "30px"
                        },
                        { data: "natur", title: resurses.getText("table_field_natur"), width: "50px", orderable: true, searchable: true },
                        { data: "datetime", title: resurses.getText("table_field_datetime"), width: "100px", orderable: true, searchable: true },
                        { data: "station_on", title: resurses.getText("table_field_station_on"), width: "200px", orderable: true, searchable: false },
                        { data: "way", title: resurses.getText("table_field_way"), width: "50px", orderable: true, searchable: false },
                        { data: "napr", title: resurses.getText("table_field_napr"), width: "50px", orderable: true, searchable: false },
                        { data: "count_wagons", title: resurses.getText("table_field_count_wagons"), width: "50px", orderable: true, searchable: false },
                        { data: "count_nathist", title: resurses.getText("table_field_count_nathist"), width: "50px", orderable: true, searchable: false },
                        { data: "status_name", title: resurses.getText("table_field_status"), width: "50px", orderable: true, searchable: false },
                        { data: "close", title: resurses.getText("table_field_close"), width: "150px", orderable: true, searchable: false },
                        { data: "list_wagons", title: resurses.getText("table_field_list_wagons"), width: "150px", orderable: true, searchable: false },
                        { data: "list_no_set_wagons", title: resurses.getText("table_field_list_no_set_wagons"), width: "150px", orderable: true, searchable: false },
                        { data: "list_no_update_wagons", title: resurses.getText("table_field_list_no_update_wagons"), width: "150px", orderable: true, searchable: false },
                    ],
                });
                this.obj_table = $('DIV#table-transfer-arrival_wrapper');
                panel_table_arrival.initPanel(this.obj_table);
                //this.initEventSelect();
                this.initEventSelectChild();
                this.obj.columns([10, 11, 12]).visible(false, true);
            },
            // Показать таблицу с данными
            viewTable: function (data_refresh) {
                OnBegin();
                if (this.list == null | data_refresh == true | (this.start != start | this.stop != stop)) {
                    // Обновим данные
                    getAsyncRWBufferArrivalSostav(
                        start,
                        stop,
                        function (result) {
                            table_arrival.start = start;
                            table_arrival.stop = stop;
                            table_arrival.list = result;
                            table_arrival.loadDataTable(result);
                            table_arrival.obj.draw();
                        }
                    );
                } else {
                    table_arrival.loadDataTable(this.list);
                    table_arrival.obj.draw();
                };
            },
            // Загрузить данные
            loadDataTable: function (data) {
                this.list = data;
                this.obj.clear();
                for (i = 0; i < data.length; i++) {
                    var station = rw_stations.selectStationKIS(data[i].id_station_kis);
                    var wagons = data[i].count_wagons != null ? data[i].count_wagons : "-";
                    var wagons_set = data[i].count_set_wagons != null ? " (" + data[i].count_set_wagons + ")" : " (-)";
                    var nathist = data[i].count_nathist != null ? data[i].count_nathist : "-";
                    var nathist_set = data[i].count_set_nathist != null ? " (" + data[i].count_set_nathist + ")" : " (-)";
                    var close = data[i].close_user + " (" + data[i].close + ")" + (data[i].close_comment != null ? " - <span>" + data[i].close_comment + "</span>" : "");
                    this.obj.row.add({
                        "id": data[i].id,
                        "natur": data[i].natur,
                        "datetime": data[i].datetime,
                        "id_station_kis": data[i].id_station_kis,
                        "station_on": station != null ? (lang == 'en' ? station.name_en : station.name_ru) : '?',
                        "way": data[i].way_num,
                        "napr": data[i].napr,
                        "count_wagons": wagons + wagons_set,
                        "count_nathist": nathist + nathist_set,
                        "status_id": data[i].status,
                        "status": rw_status.selectStatusName(data[i].status),
                        "status_name": resurses.getText(rw_status.selectStatusName(data[i].status)),
                        "close": data[i].close != null ? close : null,
                        "list_wagons": data[i].list_wagons,
                        "list_no_set_wagons": data[i].list_no_set_wagons,
                        "list_no_update_wagons": data[i].list_no_update_wagons,
                        "message": data[i].message,
                        "day": data[i].day,
                        "month": data[i].month,
                        "year": data[i].year,
                        "hour": data[i].hour,
                        "minute": data[i].minute,
                        "cwagons": data[i].count_wagons,
                        "swagons": data[i].count_set_wagons,
                        "cnathist": data[i].count_nathist,
                        "snathist": data[i].count_set_nathist,
                        "close_comment": data[i].close_comment,
                    });
                }
                LockScreenOff();
            },
            // Инициализация события выбора поля
            initEventSelect: function () {
                this.html_table.find('tbody')
                    .on('click', 'tr', function () {
                        var id = $(this).attr('id');
                        if (id != 'detali-transfer') {
                            table_arrival.clearSelect();
                            $(this).addClass('selected');

                        }

                    });
            },
            // Сбросить выбор поля
            clearSelect: function () {
                this.html_table.find('tbody tr').removeClass('selected');
            },
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
                                '<div id="tabs-detali' + row.data().id + '-1" class="tabs-detali-data"> ' +
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
            // Показать статусы переноса вагонов
            viewTableChildStatus: function (data) {
                var list_cars = getBufferArrivalCarsStatus(data);
                var target = $("#tabs-detali" + data.id + "-2");
                target.empty();
                var tab = this.createTableStatus(list_cars, data.id, data.datetime);
                target.append(tab);
            },
            // Сформировать таблицу статусы переноса вагонов
            createTableStatus: function (data, id, dt_amkr) {
                if (data == null || data.length == 0) {
                    return resurses.getText("table_not_data")
                }
                var list_tr = '<thead><tr>' +
                    '<th>' + resurses.getText("table_field_num_car") + '</th>' +
                    '<th>' + resurses.getText("table_field_reult_set_car") + '</th>' +
                    '<th>' + resurses.getText("table_field_reult_upd_car") + '</th>' +
                    '</tr></thead>';
                list_tr += '<tbody>';
                for (i = 0; i < data.length; i++) {
                    list_tr += '<tr>' +
                        //'<td>' + data[i].car + '</td>' +
                        '<td><a target="_blank" href="/railway/RW/Home/Vagon?num=' + data[i].car + '&dt_inp=' + dt_amkr + '">' + data[i].car + '</a></td>' +
                        '<td class="' + data[i].car_set + '">' + data[i].car_set + '</td>' +
                        '<td class="' + data[i].car_upd + '">' + data[i].car_upderr + '</td>' +
                        '</tr>';
                }
                list_tr += '</tbody>';
                return '<table class="table-transfer-detali" id="table-detali-status-' + id + '" cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' + list_tr + '</table>';
            },
            // Показать все поля
            viewTableChildAllFields: function (data) {
                var target = $("#tabs-detali" + data.id + "-1").DataDetali({
                    class_table: 'compact table-hover table-data-detali',
                    columns: {
                        id: { title: { ru: 'id', en: 'id' }, visible: true },
                        datetime: { title: { ru: 'Дата и время', en: 'DateAndTime' }, visible: true },
                        natur: { title: { ru: 'Натурка', en: 'Natur' }, visible: true },
                        station_on: {
                            title: { ru: 'Отправлен', en: 'Station on' },
                            visible: true,
                            value: { str: '(#0) - #1', val: ['id_station_kis', 'station_on'] }
                        },
                        way: {
                            title: { ru: 'Путь', en: 'Way' },
                            visible: true,
                        },
                        napr: {
                            title: { ru: 'Голова\Хвост', en: 'napr' },
                            visible: true,
                        },
                        count_wagons: { title: { ru: 'Кол. Vagons', en: 'Count Vagons' }, visible: true },
                        count_nathist: { title: { ru: 'Кол. Nat_Hist', en: 'Count Nat_Hist' }, visible: true },
                        status: {
                            title: { ru: 'Статус', en: 'Status' },
                            visible: true,
                            value: { str: '(#0) - #1', val: ['status_id', 'status'] }
                        },
                        close: { title: { ru: 'Закрыт', en: 'Close' }, visible: true },
                        list_wagons: { title: { ru: 'Список вагонов', en: 'List wagons' }, visible: true, class: 'list-status' },
                        list_no_set_wagons: { title: { ru: 'Не перенесенные вагоны', en: 'No set wagons' }, visible: true, class: 'list-status' },
                        list_no_update_wagons: { title: { ru: 'Не обновленные вагоны', en: 'Not updated wagons' }, visible: true, class: 'list-status' },
                        message: { title: { ru: 'Сообщение', en: 'Message' }, visible: true, class: 'list-status' },
                    },
                });
                target.DataDetali("viewDetali", data);
                //var target = $("#tabs-detali" + data.id + "-1");
                //target.empty();
                //var tab = this.createTableAllFields(data);
                //target.append(tab);
            },
            // Сформировать таблицу все поля
            //createTableAllFields: function (data) {
            //    if (data == null || data.length == 0) {
            //        return resurses.getText("table_not_data")
            //    }
            //    var list_tr = '<thead><tr>' +
            //        '<th>' + resurses.getText("table_field_value") + '</th>' +
            //        '<th>' + resurses.getText("table_field_text") + '</th>' +
            //        '</tr></thead>' +
            //        '<tbody>' +
            //        '<tr><th>' + resurses.getText("table_field_id") + '</th>' + '<td>' + data.id + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_datetime") + '</th>' + '<td>' + data.datetime + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_natur") + '</th>' + '<td>' + data.natur + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_station_on") + '</th>' + '<td>' + '(' + data.id_station_kis + ') - ' + data.station_on + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_way") + '</th>' + '<td>' + data.way + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_napr") + '</th>' + '<td>' + data.napr + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_count_wagons") + '</th>' + '<td>' + data.count_wagons + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_count_nathist") + '</th>' + '<td>' + data.count_nathist + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_status") + '</th>' + '<td>' + '(' + data.status_id + ') - ' + data.status + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_close") + '</th>' + '<td>' + data.close + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_list_wagons") + '</th>' + '<td class="list-status">' + data.list_wagons + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_list_no_set_wagons") + '</th>' + '<td class="list-status">' + data.list_no_set_wagons + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_list_no_update_wagons") + '</th>' + '<td class="list-status">' + data.list_no_update_wagons + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_list_message") + '</th>' + '<td class="list-status">' + data.message + '</td></tr>' +
            //        '</tbody>';
            //    return '<table class="table-transfer-detali" id="table-detali-all-' + data.id + '" cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' + list_tr + '</table>';
            //},
            // Добавить значения количества вагонов по таблице Prom.Vagon
            viewFieldClose: function (data) {
                if (data.close != null) {
                    var row = table_arrival.obj.row('#' + data.id).index();
                    table_arrival.obj.cell(row, 9).data(data.close_user + " (" + data.close + ")" + (data.close_comment != null ? " - <span>" + data.close_comment + "</span>" : "")).draw();
                }
            },
        },
        // Панель таблицы
        panel_table_sending = {
            html_div_panel: $('<div class="dt-buttons setup-operation" id="property"></div>'),
            //html_div_panel_info: $('<div class="setup-operation" id="last-info"></div>'),
            html_div_panel_select: $('<div class="setup-operation" id="last-select"></div>'),

            //label_last_total: $('<label class="label-text" for="label-last-total-value"></label>'),
            //label_last_total_value: $('<label class="value-text" id="label-last-total-value"></label>'),

            button_close_detali: $('<button class="ui-button ui-widget ui-corner-all"></button>'),
            initPanel: function (obj) {
                // Настроим панель info
                //this.html_div_panel_info
                //.append(this.label_last_date)
                //.append(this.label_last_date_value)
                //.append(this.label_last_total.text(resurses.getText("label_total_cars")))
                //.append(this.label_last_total_value);

                this.html_div_panel_select
                    .append(this.button_close_detali.text(resurses.getText("button_close_detali")))

                this.html_div_panel
                    //.append(this.html_div_panel_info)
                    .append(this.html_div_panel_select);
                obj.prepend(this.html_div_panel);
                // Обработка события закрыть детали
                this.button_close_detali.on('click', function () {
                    var trs = $('tr.shown');
                    for (i = 0; i < trs.length; i++) {
                        var row = table_sending.obj.row(trs[i]);
                        if (row.child.isShown()) {
                            // This row is already open - close it
                            row.child.hide();
                        }
                    }
                    $('tr').removeClass('shown');
                });
            },
        },
        // ТАБЛИЦА статуса переноса отправок
        table_sending = {
            html_table: $('#table-transfer-sending'),
            obj_table: null,
            obj: null,
            list: null,
            start: null,
            stop: null,
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
                        $(row).attr('id', data.id).addClass(data.status);
                        // Ссылка на КИС
                        var link_kis = $('<a id=' + data.id + ' target="_blank" href="/railway/KIS/Home/Natur?natur=' + data.natur +
                            '&day=' + data.day +
                            '&month=' + data.month +
                            '&year=' + data.year +
                            '&hour=' + data.hour +
                            '&minute=' + data.minute +
                            '">' + data.natur + '</a>');
                        $('td', row).eq(1).html(link_kis);
                        // Поле закрыть
                        if (data.close == null) {
                            var bt = $('<button id=' + data.id + ' class="ui-button ui-widget ui-corner-all" name="close"><span class="ui-icon ui-icon-circle-close"></span>' + (lang == 'en' ? 'Сlose' : 'Закрыть') + '</button>');
                            $('td', row).eq(7).html(bt);
                            bt.on('click', function (evt) {
                                evt.preventDefault();
                                var id = $(this).attr("id");
                                confirm_close_panel.Open(id, 1);
                            });
                        };
                        if (data.cnathist == null || data.cnathist == 0 || data.cnathist != data.snathist) {
                            $('td', row).eq(5).addClass('error-count');
                        }
                    },
                    columns: [
                        {
                            className: 'details-control',
                            orderable: false,
                            data: null,
                            defaultContent: '',
                            searchable: false, width: "30px"
                        },
                        { data: "natur", title: resurses.getText("table_field_natur"), width: "50px", orderable: true, searchable: true },
                        { data: "datetime", title: resurses.getText("table_field_datetime"), width: "100px", orderable: true, searchable: true },
                        { data: "station_from", title: resurses.getText("table_field_station_from"), width: "200px", orderable: true, searchable: false },
                        { data: "station_on", title: resurses.getText("table_field_station_on"), width: "200px", orderable: true, searchable: false },
                        { data: "count_nathist", title: resurses.getText("table_field_count_nathist"), width: "50px", orderable: true, searchable: false },
                        { data: "status_name", title: resurses.getText("table_field_status"), width: "50px", orderable: true, searchable: false },
                        { data: "close", title: resurses.getText("table_field_close"), width: "150px", orderable: true, searchable: false },
                        { data: "list_wagons", title: resurses.getText("table_field_list_wagons"), width: "150px", orderable: true, searchable: false },
                        { data: "list_no_set_wagons", title: resurses.getText("table_field_list_no_set_wagons"), width: "150px", orderable: true, searchable: false },
                    ],
                });
                this.obj_table = $('DIV#table-transfer-sending_wrapper');
                panel_table_sending.initPanel(this.obj_table);
                this.initEventSelectChild();
                this.obj.columns([8, 9]).visible(false, true);
            },
            // Показать таблицу с данными
            viewTable: function (data_refresh) {
                OnBegin();
                if (this.list == null | data_refresh == true | (this.start != start | this.stop != stop)) {
                    // Обновим данные
                    getAsyncRWBufferSendingSostav(
                        start,
                        stop,
                        function (result) {
                            table_sending.start = start;
                            table_sending.stop = stop;
                            table_sending.list = result;
                            table_sending.loadDataTable(result);
                            table_sending.obj.draw();
                        }
                    );
                } else {
                    table_sending.loadDataTable(this.list);
                    table_sending.obj.draw();
                };
            },
            // Загрузить данные
            loadDataTable: function (data) {
                this.list = data;
                this.obj.clear();
                for (i = 0; i < data.length; i++) {
                    var station_on = rw_stations.selectStationKIS(data[i].id_station_on_kis);
                    var station_from = rw_stations.selectStationKIS(data[i].id_station_from_kis);
                    var nathist = data[i].count_nathist != null ? data[i].count_nathist : "-";
                    var nathist_set = data[i].count_set_nathist != null ? " (" + data[i].count_set_nathist + ")" : " (-)";
                    var close = data[i].close_user + " (" + data[i].close + ")" + (data[i].close_comment != null ? " - <span>" + data[i].close_comment + "</span>" : "");
                    this.obj.row.add({
                        "id": data[i].id,
                        "natur": data[i].natur,
                        "datetime": data[i].datetime,
                        "id_station_from_kis": data[i].id_station_from_kis,
                        "station_from": station_from != null ? (lang == 'en' ? station_from.name_en : station_from.name_ru) : '?',
                        "id_station_on_kis": data[i].id_station_on_kis,
                        "station_on": station_on != null ? (lang == 'en' ? station_on.name_en : station_on.name_ru) : '?',
                        "count_nathist": nathist + nathist_set,
                        "status_id": data[i].status,
                        "status": rw_status.selectStatusName(data[i].status),
                        "status_name": resurses.getText(rw_status.selectStatusName(data[i].status)),
                        "close": data[i].close != null ? close : null,
                        "list_wagons": data[i].list_wagons,
                        "list_no_set_wagons": data[i].list_no_set_wagons,
                        "message": data[i].message,
                        "cnathist": data[i].count_nathist,
                        "snathist": data[i].count_set_nathist,
                        "close_comment": data[i].close_comment,
                        "day": data[i].day,
                        "month": data[i].month,
                        "year": data[i].year,
                        "hour": data[i].hour,
                        "minute": data[i].minute,
                    });
                }
                LockScreenOff();
            },
            // Инициализация события выбора поля
            initEventSelect: function () {
                this.html_table.find('tbody')
                    .on('click', 'tr', function () {
                        var id = $(this).attr('id');
                        if (id != 'detali-transfer') {
                            table_sending.clearSelect();
                            $(this).addClass('selected');

                        }

                    });
            },
            // Сбросить выбор поля
            clearSelect: function () {
                this.html_table.find('tbody tr').removeClass('selected');
            },

            initEventSelectChild: function () {
                this.html_table.find('tbody')
                    .on('click', 'td.details-control', function () {
                        var tr = $(this).closest('tr');
                        var row = table_sending.obj.row(tr);
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
                                '<div id="tabs-detali' + row.data().id + '-1" class="tabs-detali-data"> ' +
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
                            table_sending.viewTableChildAllFields(row.data());
                            table_sending.viewTableChildStatus(row.data());
                            tr.addClass('shown');
                        }
                    });
            },
            // Показать статусы переноса вагонов
            viewTableChildStatus: function (data) {
                var list_cars = getBufferSendingCarsStatus(data);
                var target = $("#tabs-detali" + data.id + "-2");
                target.empty();
                var tab = this.createTableStatus(list_cars, data.id, data.datetime);
                target.append(tab);
            },
            // Сформировать таблицу статусы переноса вагонов
            createTableStatus: function (data, id, dt_out) {
                if (data == null || data.length == 0) {
                    return resurses.getText("table_not_data")
                }
                var list_tr = '<thead><tr>' +
                    '<th>' + resurses.getText("table_field_num_car") + '</th>' +
                    '<th>' + resurses.getText("table_field_reult_set_car") + '</th>' +
                    '</tr></thead>';
                list_tr += '<tbody>';
                for (i = 0; i < data.length; i++) {
                    list_tr += '<tr>';
                    if (data[i].car != null) {
                        list_tr += '<td><a target="_blank" href="/railway/RW/Home/Vagon?num=' + data[i].car + '&dt_out=' + dt_out + '">' + data[i].car + '</a></td>' +
                            '<td class="' + data[i].car_set + '">' + data[i].car_seterr + '</td>';
                    } else {
                        list_tr += '<td colspan="2" class="' + data[i].car_set + '">' + data[i].car_seterr + '</td>';
                    }
                    list_tr += '</tr>';
                }
                list_tr += '</tbody>';
                return '<table class="table-transfer-detali" id="table-detali-status-' + id + '" cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' + list_tr + '</table>';
            },
            // Показать все поля
            viewTableChildAllFields: function (data) {
                var target = $("#tabs-detali" + data.id + "-1").DataDetali({
                    class_table: 'compact table-hover table-data-detali',
                    columns: {
                        id: { title: { ru: 'id', en: 'id' }, visible: true },
                        datetime: { title: { ru: 'Дата и время', en: 'DateAndTime' }, visible: true },
                        natur: { title: { ru: 'Натурка', en: 'Natur' }, visible: true },
                        station_from: {
                            title: { ru: 'Отправлен', en: 'Station from' },
                            visible: true,
                            value: { str: '(#0) - #1', val: ['id_station_from_kis', 'station_from'] }
                        },
                        station_on: {
                            title: { ru: 'Отправлен', en: 'Station on' },
                            visible: true,
                            value: { str: '(#0) - #1', val: ['id_station_on_kis', 'station_on'] }
                        },
                        count_nathist: { title: { ru: 'Кол. вагонов', en: 'Count nathist' }, visible: true },
                        status: {
                            title: { ru: 'Статус', en: 'Status' },
                            visible: true,
                            value: { str: '(#0) - #1', val: ['status_id', 'status'] }
                        },
                        close: { title: { ru: 'Закрыт', en: 'Close' }, visible: true },
                        list_wagons: { title: { ru: 'Список вагонов', en: 'List wagons' }, visible: true, class: 'list-status' },
                        list_no_set_wagons: { title: { ru: 'Не перенесенные вагоны', en: 'No set wagons' }, visible: true, class: 'list-status' },
                        message: { title: { ru: 'Сообщение', en: 'Message' }, visible: true, class: 'list-status' },
                    },
                });
                target.DataDetali("viewDetali", data);
                //target.empty();
                //var tab = this.createTableAllFields(data);
                //target.append(tab);
            },
            //// Сформировать таблицу все поля
            //createTableAllFields: function (data) {
            //    if (data == null || data.length == 0) {
            //        return resurses.getText("table_not_data")
            //    }
            //    var list_tr = '<thead><tr>' +
            //        '<th>' + resurses.getText("table_field_value") + '</th>' +
            //        '<th>' + resurses.getText("table_field_text") + '</th>' +
            //        '</tr></thead>' +
            //        '<tbody>' +
            //        '<tr><th>' + resurses.getText("table_field_id") + '</th>' + '<td>' + data.id + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_datetime") + '</th>' + '<td>' + data.datetime + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_natur") + '</th>' + '<td>' + data.natur + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_station_from") + '</th>' + '<td>' + '(' + data.id_station_from_kis + ') - ' + data.station_from + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_station_on") + '</th>' + '<td>' + '(' + data.id_station_on_kis + ') - ' + data.station_on + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_count_nathist") + '</th>' + '<td>' + data.count_nathist + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_status") + '</th>' + '<td>' + '(' + data.status_id + ') - ' + data.status + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_close") + '</th>' + '<td>' + data.close + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_list_wagons") + '</th>' + '<td class="list-status">' + data.list_wagons + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_list_no_set_wagons") + '</th>' + '<td class="list-status">' + data.list_no_set_wagons + '</td></tr>' +
            //        '<tr><th>' + resurses.getText("table_field_list_message") + '</th>' + '<td class="list-status">' + data.message + '</td></tr>' +
            //        //'<tr><th>' + resurses.getText("table_field_close_comment") + '</th>' + '<td class="list-status">' + data.close_comment + '</td></tr>' +
            //        '</tbody>';
            //    return '<table class="table-transfer-detali" id="table-detali-all-' + data.id + '" cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' + list_tr + '</table>';
            //},
            // Добавить значения количества вагонов по таблице Prom.Vagon
            viewFieldClose: function (data) {
                if (data.close != null) {
                    var row = table_sending.obj.row('#' + data.id).index();
                    table_sending.obj.cell(row, 7).data(data.close_user + " (" + data.close + ")" + (data.close_comment != null ? " - <span>" + data.close_comment + "</span>" : "")).draw();
                }
            },
        },
        // Панель подтверждения закрытия
        confirm_close_panel = {
            html_div: $("#close-confirm"),
            html_txt: $("#close-txt"),
            obj: null,
            id_close: null,
            type: null,
            initObject: function () {
                this.obj = this.html_div.dialog({
                    resizable: false,
                    modal: true,
                    autoOpen: false,
                    height: "auto",
                    width: 500,
                    buttons: {
                        "Закрыть": function () {
                            $(this).dialog("close");
                            confirm_close_panel.CloseSostav(confirm_close_panel.id_close, confirm_close_panel.html_txt.text());
                        },
                        Cancel: function () {
                            $(this).dialog("close");
                        }
                    }
                });
            },
            Open: function (id, type) {
                confirm_close_panel.id_close = id;
                confirm_close_panel.type = type;
                confirm_close_panel.html_txt.text("");
                $('#close-comment-text').text(resurses.getText("label_close_comment_text"));
                this.obj.dialog("option", "title", resurses.getText("confirm_close_panel_form_text"));
                this.obj.dialog("open");
            },
            CloseSostav: function (id, txt) {
                if (confirm_close_panel.type == 0) {
                    $.ajax({
                        url: '/railway/api/kis/transfer/arrival/' + id + '/close',
                        type: 'PUT',
                        data: JSON.stringify(txt),
                        contentType: "application/json;charset=utf-8",
                        success: function (data) {
                            if (Number(data) > 0) {
                                getAsyncRWBufferArrivalSostavOfID(
                                    data,
                                    function (result) {
                                        table_arrival.viewFieldClose(result);
                                    });
                            } else {
                                alert(resurses.getText("message_error_no_close_sostav") + data);
                            }

                        },
                        error: function (x, y, z) {
                            alert(x + '\n' + y + '\n' + z);
                        }
                    });
                }
                if (confirm_close_panel.type == 1) {
                    $.ajax({
                        url: '/railway/api/kis/transfer/sending/' + id + '/close',
                        type: 'PUT',
                        data: JSON.stringify(txt),
                        contentType: "application/json;charset=utf-8",
                        success: function (data) {
                            if (Number(data) > 0) {
                                getAsyncRWBufferSendingSostavOfID(
                                    data,
                                    function (result) {
                                        table_sending.viewFieldClose(result);
                                    });
                            } else {
                                alert(resurses.getText("message_error_no_close_sostav") + data);
                            }

                        },
                        error: function (x, y, z) {
                            alert(x + '\n' + y + '\n' + z);
                        }
                    });
                }

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
    OnBegin();
    resurses.initObject("/railway/Scripts/KIS/kis.json",
        function () {
            // Загружаем дальше
            $('#label-select-date-range').text(resurses.getText("label-select-date-range"));
            $('#label-to').text(resurses.getText("table_message_separator"));
            $('#to-excel').text(resurses.getText("button_to_excel"));

            datetime_range.initObject();
            confirm_close_panel.initObject();
            OnBegin();
            rw_stations.initObject(
                function (data) {
                    rw_status.initObject();

                    table_arrival.initObject();
                    table_sending.initObject();

                    tab_type_transfer.initObject(); // Типы переносов
                });
        }); // локализация

});