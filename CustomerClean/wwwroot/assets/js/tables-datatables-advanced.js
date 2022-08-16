/**
 * DataTables Advanced (jquery)
 */

'use strict';

$(function () {

  var dt_ajax_table = $('.dt_ajax_table'),
    dt_filter_table = $('.dt-column-search'),
    dt_adv_filter_table = $('.dt-advanced-search'),
    dt_responsive_table = $('.dt-responsive'),
    startDateEle = $('.start_date'),
    endDateEle = $('.end_date');

  // Advanced Search Functions Starts
  // --------------------------------------------------------------------

  // Datepicker for advanced filter
  var rangePickr = $('.flatpickr-range'),
    dateFormat = 'YYYY/MM/DD';

  if (rangePickr.length) {
    rangePickr.flatpickr({
      mode: 'range',
      locale: 'fa',
      dateFormat: 'Y/m/d',
      orientation: isRtl ? 'auto right' : 'auto left',
      onClose: function (selectedDates, dateStr, instance) {
        var startDate = '',
          endDate = new Date();
        if (selectedDates[0] != undefined) {
          startDate = moment(selectedDates[0]).format('YYYY/MM/DD');
          startDateEle.val(startDate);
        }
        if (selectedDates[1] != undefined) {
          endDate = moment(selectedDates[1]).format('YYYY/MM/DD');
          endDateEle.val(endDate);
        }
        $(rangePickr).trigger('change').trigger('keyup');
      },
      disableMobile: true
    });
  }

  // Filter column wise function
  function filterColumn(i, val) {
    if (i == 5) {
      var startDate = startDateEle.val(),
        endDate = endDateEle.val();
      if (startDate !== '' && endDate !== '') {
        $.fn.dataTableExt.afnFiltering.length = 0; // Reset datatable filter
        dt_adv_filter_table.dataTable().fnDraw(); // Draw table after filter
        filterByDate(i, startDate, endDate); // We call our filter function
      }
      dt_adv_filter_table.dataTable().fnDraw();
    } else {
      dt_adv_filter_table.DataTable().column(i).search(val, false, true).draw();
    }
  }

  // Advance filter function
  // We pass the column location, the start date, and the end date
  $.fn.dataTableExt.afnFiltering.length = 0;
  var filterByDate = function (column, startDate, endDate) {
    // Custom filter syntax requires pushing the new filter to the global filter array
    $.fn.dataTableExt.afnFiltering.push(function (oSettings, aData, iDataIndex) {
      var rowDate = normalizeDate(aData[column]),
        start = normalizeDate(startDate),
        end = normalizeDate(endDate);

      // If our date from the row is between the start and end
      if (start <= rowDate && rowDate <= end) {
        return true;
      } else if (rowDate >= start && end === '' && start !== '') {
        return true;
      } else if (rowDate <= end && start === '' && end !== '') {
        return true;
      } else {
        return false;
      }
    });
  };

  // converts date strings to a Date object, then normalized into a YYYYMMMDD format (ex: 20131220). Makes comparing dates easier. ex: 20131220 > 20121220
  var normalizeDate = function (dateString) {
    var date = new Date(dateString);
    var normalized =
      date.getFullYear() + '' + ('0' + (date.getMonth() + 1)).slice(-2) + '' + ('0' + date.getDate()).slice(-2);
    return normalized;
  };
  // Advanced Search Functions Ends

  // Ajax Sourced Server-side
  // --------------------------------------------------------------------






    if ($("#users-list-datatable").length > 0) {
        usersTable = $("#users-list-datatable").DataTable({
            autoWidth: true,
            processing: true,
            serverSide: true,
            paging: true,
            searching: { regex: true },
            ajax: {
                url: "/GetCustomer",
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                data: function (data) {
                    return JSON.stringify(data);
                },


            },
            "columns": [
                { "data": "sys_Id" },
                { "data": "fName" },
                { "data": "lname" },
                { "data": "mobile" },
                { "data": "gride_id" },
                { "data": "city.province.name" },
                { "data": "city.name" },
                
                {
                    data: "id",
                    render: function (data, type, row) {
                        return '<a  href=\'/Home/EditeCustomer/' + data + '\' class="btn btn-warning text-white">ویرایش</a>';
                    }
                }
                ,
                {
                    data: "id",
                    render: function (data, type, row) {
                        return '<a  onclick=\'DelContact(' + data + ')\' class="btn btn-danger text-white ">حذف</a>';
                    }
                }
            ],

            responsive: true,


            language: {
                "sEmptyTable": "هیچ داده ای در جدول وجود ندارد",
                "sInfo": "نمایش _START_ تا _END_ از _TOTAL_ رکورد",
                "sInfoEmpty": "نمایش 0 تا 0 از 0 رکورد",
                "sInfoFiltered": "(فیلتر شده از _MAX_ رکورد)",
                "sInfoPostFix": "",
                "sInfoThousands": ",",
                "sLengthMenu": "نمایش _MENU_ رکورد",
                "sLoadingRecords": "در حال بارگزاری...",
                "sProcessing": "در حال پردازش...",
                "sSearch": "جستجو: ",
                "sZeroRecords": "رکوردی با این مشخصات پیدا نشد",
                "oPaginate": {
                    "sFirst": "ابتدا",
                    "sLast": "انتها",
                    "sNext": "بعدی",
                    "sPrevious": "قبلی"
                },
                "oAria": {
                    "sSortAscending": ": فعال سازی نمایش به صورت صعودی",
                    "sSortDescending": ": فعال سازی نمایش به صورت نزولی"
                },

            }
        });
    };
    
  // Column Search

  // --------------------------------------------------------------------

  if (dt_filter_table.length) {
    // Setup - add a text input to each footer cell
    $('.dt-column-search thead tr').clone(true).appendTo('.dt-column-search thead');
    $('.dt-column-search thead tr:eq(1) th').each(function (i) {
      var title = $(this).text();
      $(this).html('<input type="text" class="form-control" placeholder="جستجوی ' + title + '" />');

      $('input', this).on('keyup change', function () {
        if (dt_filter.column(i).search() !== this.value) {
          dt_filter.column(i).search(this.value).draw();
        }
      });
    });

    var dt_filter = dt_filter_table.DataTable({
      ajax: assetsPath + 'json/table-datatable.json',
      columns: [
        { data: 'full_name' },
        { data: 'email' },
        { data: 'post' },
        { data: 'city' },
        { data: 'start_date' },
        { data: 'salary' }
      ],
      orderCellsTop: true,
      dom: '<"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6 d-flex justify-content-center justify-content-md-end"f>><"table-responsive"t><"row"<"col-sm-12 col-md-6"i><"col-sm-12 col-md-6"p>>'
    });
  }

  // Advanced Search
  // --------------------------------------------------------------------

  // Advanced Filter table
  if (dt_adv_filter_table.length) {
    var dt_adv_filter = dt_adv_filter_table.DataTable({
      dom: "<'row'<'col-sm-12'tr>><'row'<'col-sm-12 col-md-6'i><'col-sm-12 col-md-6 dataTables_pager'p>>",
      ajax: assetsPath + 'json/table-datatable.json',
      columns: [
        { data: '' },
        { data: 'full_name' },
        { data: 'email' },
        { data: 'post' },
        { data: 'city' },
        { data: 'start_date' },
        { data: 'salary' }
      ],

      columnDefs: [
        {
          className: 'control',
          orderable: false,
          targets: 0,
          render: function (data, type, full, meta) {
            return '';
          }
        }
      ],
      orderCellsTop: true,
      responsive: {
        details: {
          display: $.fn.dataTable.Responsive.display.modal({
            header: function (row) {
              var data = row.data();
              return 'جزئیات ' + data['full_name'];
            }
          }),
          type: 'column',
          renderer: function (api, rowIdx, columns) {
            var data = $.map(columns, function (col, i) {
              return col.title !== '' // ? Do not show row in modal popup if title is blank (for check box)
                ? '<tr data-dt-row="' +
                    col.rowIndex +
                    '" data-dt-column="' +
                    col.columnIndex +
                    '">' +
                    '<td>' +
                    col.title +
                    ':' +
                    '</td> ' +
                    '<td>' +
                    col.data +
                    '</td>' +
                    '</tr>'
                : '';
            }).join('');

            return data ? $('<table class="table"/><tbody />').append(data) : false;
          }
        }
      }
    });
  }

  // on key up from input field
  $('input.dt-input').on('keyup', function () {
    filterColumn($(this).attr('data-column'), $(this).val());
  });

  // Responsive Table
  // --------------------------------------------------------------------

  if (dt_responsive_table.length) {
    var dt_responsive = dt_responsive_table.DataTable({
      ajax: assetsPath + 'json/table-datatable.json',
      columns: [
        { data: '' },
        { data: 'full_name' },
        { data: 'email' },
        { data: 'post' },
        { data: 'city' },
        { data: 'start_date' },
        { data: 'salary' },
        { data: 'age' },
        { data: 'experience' },
        { data: 'status' }
      ],
      columnDefs: [
        {
          className: 'control',
          orderable: false,
          targets: 0,
          searchable: false,
          render: function (data, type, full, meta) {
            return '';
          }
        },
        {
          // Label
          targets: -1,
          render: function (data, type, full, meta) {
            var $status_number = full['status'];
            var $status = {
              1: { title: 'کنونی', class: 'bg-label-primary' },
              2: { title: 'حرفه‌ای', class: ' bg-label-success' },
              3: { title: 'رد شده', class: ' bg-label-danger' },
              4: { title: 'استعفا داده', class: ' bg-label-warning' },
              5: { title: 'درخواست داده', class: ' bg-label-info' }
            };
            if (typeof $status[$status_number] === 'undefined') {
              return data;
            }
            return (
              '<span class="badge rounded-pill ' +
              $status[$status_number].class +
              '">' +
              $status[$status_number].title +
              '</span>'
            );
          }
        }
      ],
      // scrollX: true,
      destroy: true,
      dom: '<"row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6 d-flex justify-content-center justify-content-md-end"f>>t<"row"<"col-sm-12 col-md-6"i><"col-sm-12 col-md-6"p>>',
      responsive: {
        details: {
          display: $.fn.dataTable.Responsive.display.modal({
            header: function (row) {
              var data = row.data();
              return 'جزئیات ' + data['full_name'];
            }
          }),
          type: 'column',
          renderer: function (api, rowIdx, columns) {
            var data = $.map(columns, function (col, i) {
              return col.title !== '' // ? Do not show row in modal popup if title is blank (for check box)
                ? '<tr data-dt-row="' +
                    col.rowIndex +
                    '" data-dt-column="' +
                    col.columnIndex +
                    '">' +
                    '<td>' +
                    col.title +
                    ':' +
                    '</td> ' +
                    '<td>' +
                    col.data +
                    '</td>' +
                    '</tr>'
                : '';
            }).join('');

            return data ? $('<table class="table"/><tbody />').append(data) : false;
          }
        }
      }
    });
  }

  // Filter form control to default size
  // ? setTimeout used for multilingual table initialization
  setTimeout(() => {
    $('.dataTables_filter .form-control').removeClass('form-control-sm');
    $('.dataTables_length .form-select').removeClass('form-select-sm');
  }, 200);
});
