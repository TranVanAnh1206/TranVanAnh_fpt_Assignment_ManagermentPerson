"use strict";

$(function () {
    //
    toastr.options = {
        closeButton: false,
        debug: false,
        newestOnTop: false,
        progressBar: false,
        positionClass: "toast-top-right",
        preventDuplicates: false,
        onclick: null,
        showDuration: "300",
        hideDuration: "1000",
        timeOut: "5000",
        extendedTimeOut: "1000",
        showEasing: "swing",
        hideEasing: "linear",
        showMethod: "fadeIn",
        hideMethod: "fadeOut",
    };

    $("#slcRole").on("change", function () {
        let value = $(this).val();

        if (value === "1") {
            $("#blockProfessor").removeClass("d-none");
            $("#blockProfessor").addClass("d-block");

            $("#blockStudent").removeClass("d-block");
            $("#blockStudent").addClass("d-none");
        } else if (value === "2") {
            $("#blockProfessor").removeClass("d-block");
            $("#blockProfessor").addClass("d-none");

            $("#blockStudent").removeClass("d-none");
            $("#blockStudent").addClass("d-block");
        } else {
            $("#blockProfessor").removeClass("d-block");
            $("#blockProfessor").addClass("d-none");

            $("#blockStudent").removeClass("d-block");
            $("#blockStudent").addClass("d-none");
        }
    });

    $("#addModal").on("modal.bs.hide", function () {
        $("#frmCreate").clear();
    });

    var baseUrl = "https://localhost:44362/api";
    var currentPage = 1;
    var totalPages = 1;
    var pageSize = 5;

    $(document).on("click", ".edit", function () {
        var id = $(this).data("id");

        $.ajax({
            url: `${baseUrl}/People/get-by-id/${id}`,
            method: "GET",
            success: function (response) {
                $("#editId").val(response.id);
                $("#editname").val(response.name);
                $("#editphoneNumber").val(response.phoneNumber);
                $("#editemail").val(response.emailAddress);
                $("#editaddress").val(response.addressId);

                if (response.professor) {
                    $("#editslcRole").val("1");
                    $("#editslcRole").attr("disabled", true);

                    $("#editblockProfessor").removeClass("d-none").addClass("d-block");
                    $("#editblockStudent").removeClass("d-block").addClass("d-none");
                    $("#editSalary").val(response.professor.salary);
                } else if (response.student) {
                    $("#editslcRole").val("2");
                    $("#editslcRole").attr("disabled", true);

                    $("#editblockProfessor").removeClass("d-block").addClass("d-none");
                    $("#editblockStudent").removeClass("d-none").addClass("d-block");
                    $("#editStudentNumber").val(response.student.studentNumber);
                    $("#editAvegerMark").val(response.student.avengerMark);
                } else {
                    $("#editslcRole").val("");
                    $("#editslcRole").attr("disabled", false);

                    $("#editblockProfessor, #editblockStudent").addClass("d-none");
                }

                $("#editModal").modal("show");
            },
            error: function (err) {
                console.error(err);
            },
        });
    });

    $("#frmEdit").on("submit", function (e) {
        e.preventDefault();

        let role = $("#editslcRole").val();
        let id = $("#editId").val();

        if (role === "1") {
            let professorData = {
                id: id,
                name: $("#editname").val(),
                phoneNumber: $("#editphoneNumber").val(),
                emailAddress: $("#editemail").val(),
                addressId: parseInt($("#editaddress").val()),
                salary: $("#editSalary").val(),
            };

            $.ajax({
                url: `${baseUrl}/Professor/update/${id}`,
                method: "PUT",
                contentType: "application/json",
                data: JSON.stringify(professorData),
                success: function (response) {
                    if (response === 1) GetAllPeople(1, pageSize, "");
                    toastr["success"]("Edit professor successfully!");

                    $("#editModal").modal("hide");
                },
                error: function (err) {
                    console.error(err.toString());
                },
            });
        } else if (role === "2") {
            let studentData = {
                id: id,
                name: $("#editname").val(),
                phoneNumber: $("#editphoneNumber").val(),
                emailAddress: $("#editemail").val(),
                addressId: parseInt($("#editaddress").val()),
                studentNumber: $("#editStudentNumber").val(),
                avengerMark: $("#editAvegerMark").val(),
            };

            $.ajax({
                url: `${baseUrl}/Student/update/${id}`,
                method: "PUT",
                contentType: "application/json",
                data: JSON.stringify(studentData),
                success: function (response) {
                    if (response === 1) GetAllPeople(1, pageSize, "");
                    toastr["success"]("Edit student successfully!");

                    $("#editModal").modal("hide");
                },
                error: function (err) {
                    console.error(err.toString());
                },
            });
        }
    });

    $(document).on("click", ".delete", function () {
        var id = $(this).data("id");

        Swal.fire({
            title: "Xóa person?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            cancelButtonText: "Hủy",
            confirmButtonText: "Xóa!",
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `${baseUrl}/People/delete/${id}`,
                    method: "DELETE",
                    success: function (response) {
                        if (response === 1) {
                            GetAllPeople(1, pageSize, "");
                            toastr["success"]("Delete person successfully!");
                        }
                    },
                    error: function (err) {
                        console.error(err);
                    },
                });
            }
        });
    });

    let searchTimeout;
    $("#inputSearch").on("input", function () {
        clearTimeout(searchTimeout);

        searchTimeout = setTimeout(function () {
            var filter = $("#inputSearch").val();

            if (filter) GetAllPeople(1, pageSize, filter);
            else GetAllPeople(1, pageSize, "");
        }, 2000);
    });

    $("#frmCreate").on("submit", function (e) {
        e.preventDefault();

        let role = $("#slcRole").val();

        if (role === "1") {
            let professorData = {
                name: $("#name").val(),
                phoneNumber: $("#phoneNumber").val(),
                emailAddress: $("#email").val(),
                addressId: parseInt($("#address").val()),
                salary: $("#Salary").val(),
            };

            $.ajax({
                url: `${baseUrl}/Professor/create`,
                method: "POST",
                contentType: "application/json",
                data: JSON.stringify(professorData),
                success: function (response) {
                    if (response === 1) GetAllPeople(1, pageSize, "");
                    toastr["success"]("Create professor successfully!");

                    $("#addModal").modal("hide");
                },
                error: function (err) {
                    console.error(err.toString());
                },
            });
        } else if (role === "2") {
            let studentData = {
                name: $("#name").val(),
                phoneNumber: $("#phoneNumber").val(),
                emailAddress: $("#email").val(),
                addressId: parseInt($("#address").val()),
                studentNumber: $("#StudentNumber").val(),
                avengerMark: $("#AvegerMark").val(),
            };

            $.ajax({
                url: `${baseUrl}/Student/create`,
                method: "POST",
                contentType: "application/json",
                data: JSON.stringify(studentData),
                success: function (response) {
                    if (response === 1) GetAllPeople(1, pageSize, "");
                    toastr["success"]("Create student successfully!");

                    $("#addModal").modal("hide");
                },
                error: function (err) {
                    console.error(err.toString());
                },
            });
        }
    });

    function GetAllPeople(page, pageSize, filter) {
        var htmls = "";

        $.ajax({
            url: `${baseUrl}/People/get-list?Filter=${filter}&PageNumber=${page}&PageSize=${pageSize}`,
            method: "GET",
            success: function (response) {
                console.log(response);

                response.datas.map(function (t, n) {
                    htmls += `
                        <tr class="my-2">
                            <th scope="row">${n + 1 + (page - 1) * pageSize}</th>
                            <td>${t.name}</td>
                            <td>${t.phoneNumber}</td>
                            <td>${t.emailAddress}   </td>
                            <td>${!t.student ? (!t.professor ? "" : "professor") : "student"}</td>
                            <td>${t.address.name}</td>
                            <td>
                                <button data-id=${t.id} class="btn btn-danger delete">Del</button>
                                <button data-id=${t.id} class="btn btn-primary edit">Edit</button>
                            </td>
                        </tr>`;
                });

                $("#tblPerson tbody").html(htmls);
                updatePagination(response.pageNumber, response.totalPage);
            },
            error: function (err) {
                console.error(err.toString());
            },
        });
    }

    function updatePagination(pageNumber, totalPageCount) {
        currentPage = pageNumber;
        totalPages = totalPageCount;

        $("#pageInfo").text(`Trang ${currentPage} / ${totalPageCount}`);

        $("#prevPage").prop("disabled", currentPage <= 1);
        $("#nextPage").prop("disabled", currentPage >= totalPages);
    }

    $("#prevPage").on("click", function () {
        if (currentPage > 1) {
            GetAllPeople(currentPage - 1, pageSize, "");
        }
    });

    $("#nextPage").on("click", function () {
        if (currentPage < totalPages) {
            GetAllPeople(currentPage + 1, pageSize, "");
        }
    });

    GetAllPeople(1, pageSize, "");
});
