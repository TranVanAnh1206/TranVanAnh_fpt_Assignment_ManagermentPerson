"use strict";

$(function () {
    function POST_PUT(url, method_type, data, toastr_type, toastr_msg, modal) {
        $.ajax({
            url: `${baseUrl}${url}`,
            method: method_type,
            contentType: "application/json",
            data: JSON.stringify(data),
            success: function (response) {
                if (response === 1) GetAllPeople(1, pageSize, "");
                toastr[toastr_type](toastr_msg);

                $(modal).modal("hide");
            },
            error: function (err) {
                console.error(err.toString());
            },
        });
    }

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

    $("#editslcRole").on("change", function () {
        let value = $(this).val();

        if (value === "1") {
            $("#editblockProfessor").removeClass("d-none");
            $("#editblockProfessor").addClass("d-block");

            $("#editblockStudent").removeClass("d-block");
            $("#editblockStudent").addClass("d-none");
        } else if (value === "2") {
            $("#editblockProfessor").removeClass("d-block");
            $("#editblockProfessor").addClass("d-none");

            $("#editblockStudent").removeClass("d-none");
            $("#editblockStudent").addClass("d-block");
        } else {
            $("#editblockProfessor").removeClass("d-block");
            $("#editblockProfessor").addClass("d-none");

            $("#editblockStudent").removeClass("d-block");
            $("#editblockStudent").addClass("d-none");
        }
    });

    $("#addModal").on("hide.bs.modal", function () {
        $("#frmCreate")[0].reset();
        $("#slcRole").val(0);
    });

    $("#editModal").on("hide.bs.modal", function () {
        $("#frmEdit")[0].reset();
        $("#editslcRole").val(0);
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

            POST_PUT(`/Professor/update/${id}`, "PUT", professorData, "success", "Edit professor successfully!", "#editModal");
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

            POST_PUT(`/Student/update/${id}`, "PUT", studentData, "success", "Edit student successfully!", "#editModal");
        } else {
            let personData = {
                id: id,
                name: $("#editname").val(),
                phoneNumber: $("#editphoneNumber").val(),
                emailAddress: $("#editemail").val(),
                addressId: parseInt($("#editaddress").val()),
            };

            POST_PUT(`/People/update/${id}`, "PUT", personData, "success", "Edit person successfully!", "#editModal");
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

            POST_PUT("/Professor/create", "POST", professorData, "success", "Create professor successfully!", "#addModal");
        } else if (role === "2") {
            let studentData = {
                name: $("#name").val(),
                phoneNumber: $("#phoneNumber").val(),
                emailAddress: $("#email").val(),
                addressId: parseInt($("#address").val()),
                studentNumber: $("#StudentNumber").val(),
                avengerMark: $("#AvegerMark").val(),
            };

            POST_PUT("/Student/create", "POST", studentData, "success", "Create student successfully!", "#addModal");
        } else {
            let person = {
                name: $("#name").val(),
                phoneNumber: $("#phoneNumber").val(),
                emailAddress: $("#email").val(),
                addressId: parseInt($("#address").val()),
            };

            POST_PUT("/People/create", "POST", person, "success", "Create person successfully!", "#addModal");
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
