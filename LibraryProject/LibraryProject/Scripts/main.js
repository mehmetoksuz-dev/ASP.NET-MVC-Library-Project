//KATEGORI BASLANGIC

$(document).on("click", "#btnAddCtg", async function () {
    const { value: formValues } = await Swal.fire({
        title: 'Add Category',
        html:
            '<input id="ctgName" class="swal2-input">'
    })

    var ctgLen = $("#ctgName").val().length; //category length control
    if (ctgLen > 50) {
        alert("Category name can not bigger than 50!");
        return false;
    }
    var mytest = $("#ctgName").val();
    if (mytest=="") {
        alert("bos olamaz");
        return false;
    }

    var ctgName = $("#ctgName").val();
    $.ajax({
        type: 'Post',
        url: '/Category/AddJson',
        data: { "ctgName": ctgName },
        dataType: 'Json',
        success: function (data) {
            var ctgId = data.Result.Id;
            var ctgName = '<td>' + data.Result.Name + '</td>';
            var bookNumber = "<td>0</td>";
            var updateBtn = "<td><button class='btnUpdate btn btn-custom' value='" + ctgId + "'>Update</button></td>";
            var deleteBtn = "<td><button class='btnDelete btn btn-danger' value='" + ctgId + "'>Delete</button></td>";

            $("#example tbody").prepend('<tr>' + ctgName + bookNumber + updateBtn + deleteBtn + '</tr>');
            Swal.fire({
                type: 'succes',
                title: 'Category has been successfully added!',
                text: 'Processing is completed successfully!'
            });
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Category can not added!',
                text: 'Process cancelled!'
            });
        }
    });
});

$(document).on("click", ".btnUpdate", async function () {
    var ctgId = $(this).val();
    var ctgNameTd = $(this).parent("td").parent("tr").find("td:first"); //hangi td'de?
    var ctgName = ctgNameTd.html();
    const { value: formValues } = await Swal.fire({
        title: 'Update Category',
        html:
            '<input id="ctgName" value="' + ctgName + '" class="swal2-input">'
    })

    var ctgLen = $("#ctgName").val().length; //category length control
    if (ctgLen > 50) {
        alert("Category name can not bigger than 50!");
        return false;
    }

    ctgName = $("#ctgName").val();
    $.ajax({
        type: 'Post',
        url: '/Category/UpdateJson',
        data: { "ctgId": ctgId, "ctgName": ctgName },
        dataType: 'Json',
        success: function (data) {
            if (data == "1") {
                ctgNameTd.html(ctgName); //refresh olacak dinamik yenilesin
                Swal.fire({
                    type: 'succes',
                    title: 'Category has been successfully updated!',
                    text: 'Processing is completed successfully!'
                });
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'Category can not updated!',
                    text: 'Process cancelled!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Category can not added!',
                text: 'Process cancelled!'
            });
        }
    });
});

$(document).on("click", ".btnDelete", async function () {
    var tr = $(this).parent("td").parent("tr");
    var ctgId = $(this).val();
    $.ajax({
        type: 'Post',
        url: '/Category/DeleteJson',
        data: { "ctgId": ctgId }, //id ile sildim
        dataType: 'Json',
        success: function (data) {
            if (data == "1") { // 1 = islem basarili
                tr.remove();
                Swal.fire({
                    type: 'succes',
                    title: 'Category has been successfully deleted!',
                    text: 'Processing is completed successfully!'
                });
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'Category can not deleted!',
                    text: 'Process cancelled!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Category can not added!',
                text: 'Process cancelled!'
            });
        }
    });
});

//KATEGORI END //kontroller yapıldı


// Yazar js işlemleri BASLANGIC
$(document).on("click", "#btnAddWriter", async function () {
    const { value: formValues } = await Swal.fire({
        title: 'Add Writer',
        html:
            '<input id="writerName" class="swal2-input">'
    })
    var writerLen = $("#writerName").val().length; //writer length control
    if (writerLen > 50) {
        alert("Writer name can not bigger than 80!");
        return false;
    }

    var writerName = $("#writerName").val();
    debugger;
    $.ajax({
        type: 'Post',
        url: '/Writer/AddJson',
        data: { "writerName": writerName },
        dataType: 'Json',
        success: function (data) {
            var writerId = data.Result.Id;
            var writerName = '<td>' + data.Result.Name + '</td>';
            var bookNumber = "<td>0</td>";
            var updateBtn = "<td><button class='btnUpdate btn btn-custom' value='" + writerId + "'>Update</button></td>";
            var deleteBtn = "<td><button class='btnDelete btn btn-danger' value='" + writerId + "'>Delete</button></td>";

            $("#example tbody").prepend('<tr>' + writerName + bookNumber + updateBtn + deleteBtn + '</tr>');
            Swal.fire({
                type: 'succes',
                title: 'Writer has been successfully added!',
                text: 'Processing is completed successfully!'
            });
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Writer can not added!',
                text: 'Process cancelled!'
            });
        }
    });
});

$(document).on("click", ".btnWriterDelete", async function () {
    var tr = $(this).parent("td").parent("tr");
    var writerId = $(this).val();
    $.ajax({
        type: 'Post',
        url: '/Writer/DeleteJson',
        data: { "writerId": writerId }, //id ile sildim
        dataType: 'Json',
        success: function (data) {
            if (data == "1") { // 1 = islem basarili
                tr.remove();
                Swal.fire({
                    type: 'succes',
                    title: 'Writer has been successfully deleted!',
                    text: 'Processing is completed successfully!'
                });
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'Writer can not deleted!',
                    text: 'Process cancelled!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Writer can not added!',
                text: 'Process cancelled!'
            });
        }
    });
});

$(document).on("click", ".btnWriterUpdate", async function () {
    var writerId = $(this).val();
    var writerNameTd = $(this).parent("td").parent("tr").find("td:first"); //hangi td'de?
    var writerName = writerNameTd.html();
    const { value: formValues } = await Swal.fire({
        title: 'Update Writer',
        html:
            '<input id="writerName" value="' + writerName + '" class="swal2-input">'
    })

    var writerLen = $("#writerName").val().length; //writer length control
    if (writerLen > 50) {
        alert("Writer name can not bigger than 80!");
        return false;
    }

    writerName = $("#writerName").val();
    $.ajax({
        type: 'Post',
        url: '/Writer/UpdateJson',
        data: { "writerId": writerId, "writerName": writerName },
        dataType: 'Json',
        success: function (data) {
            if (data == "1") {
                writerNameTd.html(writerName); //refresh olacak dinamik yenilesin
                Swal.fire({
                    type: 'succes',
                    title: 'Writer has been successfully updated!',
                    text: 'Processing is completed successfully!'
                });
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'Writer can not updated!',
                    text: 'Process cancelled!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Writer can not added!',
                text: 'Process cancelled!'
            });
        }
    });
});

//Yazar js işlemleri END //kontroller yapıldı


//Kitapi işlemleri Başlangıç
$(document).on("click", "#btnAddCategory", function () { //btnAddCategory Click oldu mu
    var selectedCtgName = $("#categoriess").val(); //select-option html kısmından kategorileri aldık
    if (selectedCtgName != null && selectedCtgName != "") {
        var selectedId = $("#categoriess option:selected").attr("data-id"); //burada seçilen kategorinin data-id aldık.
        $("#addedCategories").append('<div id="' + selectedId + '" class="col-md-1 bg-primary ctgDelete" style="margin-right:2px; margin-bottom:2px;">' + selectedCtgName + '</div>');
        $("#categoriess option:selected").remove(); //ekleneni option'dan kaldır
    }
    else {
        alert("You selected all categories can you selected."); //veri null geldi ise ya ctg kalmadıysa
    }
});

$(document).on("click", ".ctgDelete", function () { //yanlislikla eklerse silmek için
    var id = $(this).attr("id");
    var ctgName = $(this).html();
    $("#categoriess").append('<option data-id="' + id + '">' + ctgName + '</option>'); //yanlislikla secileni option olarak geri ekledik
    $(this).remove(); //ustune tiklanani kaldir.
});

$(document).on("click", "#saveBook", function () { //burada kaldım ctgControl devam
    var values = {
        categoriess : [],
        writer : $("#writer option:selected").attr("data-id"),
        bookName : $("#bookName").val(),
        numOfBook : $("#numOfBook").val(),
        rowOfBook: $("#rowOfBook").val()
    };

    $("#addedCategories div").each(function () {
        var id = $(this).attr("id");
        values.categoriess.push(id);
    });


    $.ajax({
        type: 'Post',
        url: '/Book/AddBookJson',
        data: JSON.stringify(values),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (val) {
            if (val == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Book added successfully!',
                    text: 'Process is completed successfully!'
                });
            }
            else if("notNull"){
                Swal.fire({
                    type: 'error',
                    title: 'Book can not added!',
                    text: 'Values cannot be empty!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Book can not added!',
                text: 'Process cancelled!'
            });
        }
    });
});

$(document).on("click", ".btnBookDelete", function () {
    Swal.fire({
        title: 'Are you sure?',
        text: "Are you sure you want to delete the book?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            var bookId = $(this).val();
            var tr = $(this).parent("td").parent("tr");

            $.ajax({
                type: 'Post',
                url: '/Book/DeleteJson',
                data: { "bookId": bookId },
                dataType: 'Json',
                success: function (data) {
                    if (data == "1") {
                        tr.remove();
                        Swal.fire({
                            type: 'succes',
                            title: 'Book has been successfully deleted!',
                            text: 'Processing is completed successfully!'
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'Book can not successfully deleted!',
                            text: 'There was a problem in database!'
                        });
                    }
                },
                error: function () {
                    Swal.fire({
                        type: 'error',
                        title: 'Book can not successfully deleted!',
                        text: 'There was a problem in database!'
                    });
                }
            });
        }
    })
});

$(document).on("click", "#updateBook", function () {
    var values = {
        categoriess: [],
        writer: $("#writer option:selected").attr("data-id"),
        bookName: $("#bookName").val(),
        numOfBook: $("#numOfBook").val(),
        rowOfBook: $("#rowOfBook").val(),
        bookId : $(this).attr("data-id")
    };

    $("#addedCategories div").each(function () {
        var id = $(this).attr("id");
        values.categoriess.push(id);
    });


    $.ajax({
        type: 'Post',
        url: '/Book/UpdateBookJson',
        data: JSON.stringify(values),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (val) {
            if (val == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Book updated successfully!',
                    text: 'Process is completed successfully!'
                });
            }
            else if ("notNull") {
                Swal.fire({
                    type: 'error',
                    title: 'Book can not updated!',
                    text: 'Values cannot be empty!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Book can not updated!',
                text: 'Process cancelled!'
            });
        }
    });
});

$(document).on("click", "#giveBook", function () {
    var values = {
        memberId: $("#memberId option:selected").attr("data-id"),
        bookId: $("#bookId option:selected").attr("data-id"),
        bringDate: $("#bringDate").val(),
    };

    $.ajax({
        type: 'Post',
        url: '/BorrowBook/GiveBookJson',
        data: JSON.stringify(values),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (val) {
            if (val == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'The book was given to the user successfully!',
                    text: 'Process is completed successfully!'
                });
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'There was a problem in database!',
                    text: 'Process cancelled!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'The book can not given to the user!',
                text: 'Process cancelled!'
            });
        }
    });
});

$(document).on("click", "#updateGivenBook", function () {
    var values = {
        borrowBookId: $(this).attr("data-id"),
        memberId: $("#memberId option:selected").attr("data-id"),
        bookId: $("#bookId option:selected").attr("data-id"),
        bringDate: $("#bringDate").val(),
    };

    $.ajax({
        type: 'Post',
        url: '/BorrowBook/UpdateBorrowBookJson',
        data: JSON.stringify(values),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (val) {
            if (val == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'The book was given updated successfully!',
                    text: 'Process is completed successfully!'
                });
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'There was a problem in database!',
                    text: 'Process cancelled!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'The book was given can not updated!',
                text: 'Process cancelled!'
            });
        }
    });
});

$(document).on("click", ".markAsBrought", function () {
    Swal.fire({
        title: 'Mark?',
        text: "Do you want to mark as delivered(brought)?", //burası için hem delivered hem de brought kullandım - karışmasın.
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            var borrowBookId = $(this).val();
            var tr = $(this).parent("td").parent("tr");

            $.ajax({
                type: 'Post',
                url: '/BorrowBook/DeliveredMarkJson',
                data: { "borrowBookId": borrowBookId },
                dataType: 'Json',
                success: function (data) {
                    if (data == "1") {
                        tr.remove();
                        Swal.fire({
                            type: 'succes',
                            title: 'Book has been marked delivered!',
                            text: 'Processing is completed successfully!'
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'The book could not be marked as delivered!',
                            text: 'There was a problem in database!'
                        });
                    }
                },
                error: function () {
                    Swal.fire({
                        type: 'error',
                        title: 'The book could not be marked as delivered!',
                        text: 'There was a problem in database!'
                    });
                }
            });
        }
    })
});

//Kitap işlemleri end
//

//Uye işlemleri başlangıç
$(document).on("click", "#saveMember", function () {
    var values = {
        memberName: $("#memberName").val(),
        memberSurname: $("#memberSurname").val(),
        memberTc: $("#memberTc").val(),
        memberPhone: $("#memberPhone").val()
    };

    //control area 
    if ($("#memberName").val().length > 50) { //name control
        alert("Member name can not bigger than 50 character!");
        return false;
    }

    if ($("#memberSurname").val().length > 50) { //surname control
        alert("Member surname can not bigger than 50 character!");
        return false;
    }

    if ($("#memberTc").val().length > 11) { //tc kontrol
        alert("Please check your TC, That length can not bigger than 11 character!");
        return false;
    }
    if ($("#memberPhone").val().length > 11) { //tel kontrol
        alert("Please check your Phone, That length can not bigger than 11 character!");
        return false;
    }
    
    $.ajax({
        type: 'Post',
        url: '/Member/AddMemberJson',
        data: JSON.stringify(values),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (val) {
            if (val == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Member added successfully!',
                    text: 'Process is completed successfully!'
                });
            }
            else if ("notNull") {
                Swal.fire({
                    type: 'error',
                    title: 'Member can not added!',
                    text: 'Values cannot be empty!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Member can not added!',
                text: 'Process cancelled!'
            });
        }
    });
});

$(document).on("click", ".deleteMember", function () {
    Swal.fire({
        title: 'Are you sure?',
        text: "Are you sure you want to delete the member?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            var memberId = $(this).val();
            var tr = $(this).parent("td").parent("tr");

            $.ajax({
                type: 'Post',
                url: '/Member/DeleteMemberJson',
                data: { "memberId": memberId },
                dataType: 'Json',
                success: function (data) {
                    if (data == "1") {
                        tr.remove();
                        Swal.fire({
                            type: 'succes',
                            title: 'Member has been successfully deleted!',
                            text: 'Processing is completed successfully!'
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'Member can not successfully deleted!',
                            text: 'There was a problem in database!'
                        });
                    }
                },
                error: function () {
                    Swal.fire({
                        type: 'error',
                        title: 'Member can not successfully deleted!',
                        text: 'There was a problem in database!'
                    });
                }
            });
        }
    })
});

$(document).on("click", "#updateMember", function () {
    var values = {
        memberName: $("#memberName").val(),
        memberSurname: $("#memberSurname").val(),
        memberTc: $("#memberTc").val(),
        memberPhone: $("#memberPhone").val(),
        memberId: $(this).attr("data-id")
    };

    $.ajax({
        type: 'Post',
        url: '/Member/UpdateMemberJson',
        data: JSON.stringify(values),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (val) {
            if (val == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Member updated successfully!',
                    text: 'Process is completed successfully!'
                });
            }
            else if ("notNull") {
                Swal.fire({
                    type: 'error',
                    title: 'Member can not updated!',
                    text: 'Values cannot be empty!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Member can not updated!',
                text: 'Process cancelled!'
            });
        }
    });
});

$(document).on("click", "#addMemberShip", function () {
    var memberId = $("#memberId").val();
    var mail = $("#mail").val();
    var password = $("#password").val();
    var passwordAgain = $("#passwordAgain").val();

    $.ajax({
        type: 'Post',
        url: '/Membership/AddJson',
        data: { 'memberId': memberId, 'mail': mail, 'password': password, 'passwordAgain': passwordAgain },
        dataType: 'JSON',
        success: function (val) {
            if (val == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Membership Created!',
                    text: 'Process is completed successfully!'
                });
            }
            else if (val == "notNull") {
                Swal.fire({
                    type: 'error',
                    title: 'Membership can not created!',
                    text: 'Values cannot be empty!'
                });
            }
            else if (val == "samePassErr") {
                Swal.fire({
                    type: 'error',
                    title: 'Passwords have to be same!',
                    text: 'Please enter same password!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Membership can not created!',
                text: 'Process cancelled!'
            });
        }
    });
});

$(document).on("click", "#updateMemberShip", function () {
    var memberId = $("#memberId").val();
    var mail = $("#mail").val();
    var password = $("#password").val();
    var passwordAgain = $("#passwordAgain").val();

    $.ajax({
        type: 'Post',
        url: '/Membership/UpdateJson',
        data: { 'memberId': memberId, 'mail': mail, 'password': password, 'passwordAgain': passwordAgain },
        dataType: 'JSON',
        success: function (val) {
            if (val == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Membership Updated!',
                    text: 'Process is completed successfully!'
                });
            }
            else if (val == "mailNotNull") {
                Swal.fire({
                    type: 'error',
                    title: 'Membership can not updated!',
                    text: 'Mail area cannot be empty!'
                });
            }
            else if (val == "samePassErr") {
                Swal.fire({
                    type: 'error',
                    title: 'Passwords have to be same!',
                    text: 'Please enter same password!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Membership can not updated!',
                text: 'Process cancelled!'
            });
        }
    });
});

$(document).on("click", ".deleteMembership", function () {
    var memberId = $(this).val();
    var tr = $(this).parent("td").parent("tr");

    $.ajax({
        type: 'Post',
        url: '/Membership/DeleteJson',
        data: { 'memberId': memberId},
        dataType: 'JSON',
        success: function (val) {
            if (val == "1") {
                tr.remove();
                Swal.fire({
                    type: 'success',
                    title: 'Membership Deleted!',
                    text: 'Process is completed successfully!'
                });
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'Membership can not deleted!',
                    text: 'There was error in database!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Membership can not deleted!',
                text: 'Process cancelled!'
            });
        }
    });
});

$(document).on("click", "#addRole", async function () {

    var select = '<select id="roleId">' +
        '<option value="2">Moderator</option>' +
        '<option value="3">Member</option>' +
        '</select>';

    const { value: formValues } = await Swal.fire({
        title: 'Assign Role',
        html: select
    })

    var memberId = $(this).attr("data-id");
    var roleId = $("#roleId").val();
    var roleName = $("#roleId option:selected").text();
    var buton = $(this);
    $.ajax({
        type: 'Post',
        url: '/Membership/AddRoleJson',
        data: { 'memberId': memberId, 'roleId': roleId },
        dataType: 'JSON',
        success: function (val) {
            if (val == "1") {
                buton.text(roleName);
                Swal.fire({
                    type: 'success',
                    title: 'Role Assigned!',
                    text: 'Process is completed successfully!'
                });
            }
            else {
                Swal.fire({
                    type: 'error',
                    title: 'Role can not Assigned!',
                    text: 'There was error in database!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Role can not Assigned!',
                text: 'Process cancelled!'
            });
        }
    });
});
//Membership Op -- end


//Login Start

$(document).on("click", "#login", function () {
    $(this).html("Checking Informations...");
    $(this).prop("disabled", true);

    var values = {
        email : $("#email").val(),
        pass : $("#pass").val(),
        remember : false
    };

    if ($("#checkbox-signup").is(":checked")) {
        values.remember = true;
    }

    $.ajax({
        type: 'Post',
        url: '/Login/LoginControl',
        data: JSON.stringify(values),
        dataType: 'Json',
        contentType: 'application/json;charset=utf-8',
        success: function (val) {
            if (val == "Success") {
                Swal.fire({ icon: "success", title: "Login Successfull!", text: "Redirecting..." });
                window.location.href = '/Book/Index';
                //tek l
            }
            else if(val=="notNull"){
                Swal.fire({ icon: "error", title: "Login Failed!", text: "Fill in the required fields!" });
                $("#login").html("Log In");
                $("#login").prop("disabled", false);
            }
            else {
                Swal.fire({ icon: "error", title: "Login Failed!", text: "Please check your informations!" });
                $("#login").html("Log In");
                $("#login").prop("disabled", false);
            }
        },
        error: function () {
            Swal.fire({ icon: "error", title: "Error!", text: "An error occurred while logging in!" });
        },
        complete: function () {
            $("#login").html("Log In");
            $("#login").prop("disabled", false);
        }
    });
});

$(document).on("click", "#updateProfileInfo", function () {

    var mail = $("#mail").val();
    var password = $("#password").val();
    var passwordAgain = $("#passwordAgain").val();
    var tel = $("#tel").val();

    $.ajax({
        type: 'Post',
        url: '/Membership/UpdateProfileInfoJson',
        data: { 'mail': mail, 'password': password, 'passwordAgain': passwordAgain, 'tel': tel },
        dataType: 'JSON',
        success: function (val) {
            if (val == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Informations Updated!',
                    text: 'Process is completed successfully!'
                });
            }
            else if (val == "mailNotNull") {
                Swal.fire({
                    type: 'error',
                    title: 'Informations can not updated!',
                    text: 'Mail area cannot be empty!'
                });
            }
            else if (val == "samePassErr") {
                Swal.fire({
                    type: 'error',
                    title: 'Passwords have to be same!',
                    text: 'Please enter same password!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Informations can not updated!',
                text: 'Process cancelled!'
            });
        }
    });
});

//Login end

// Vote -- Start

//for recommend
$(document).ready(function () {
    $(".btnRecommend").one('click', function (event) {
        event.preventDefault();
        //do something
        $(this).closest("tr").remove();
    });
});
$(document).on("click", ".btnRecommend", function () {

    var bookId = $(this).val();

    //$("#example").on("click", ".btnRecommend", function () {
    //    $(this).closest("tr").remove();
    //});

    $.ajax({
        type: 'Post',
        url: '/Vote/VoteJson',
        data: { 'bookId': bookId },
        dataType: 'JSON',
        success: function (val) {
            if (val == "1") {
                Swal.fire({
                    
                    type: 'success',
                    title: 'Book is voted!',
                    text: 'Process is completed successfully!'
                });
            }
            else if (val == "err") {
                Swal.fire({
                    type: 'error',
                    title: 'Book can not voted!',
                    text: 'Mail area cannot be empty!'
                });
            }
            else if (val == "alreadyrated") {
                Swal.fire({
                    type: 'error',
                    title: 'Book can not voted!',
                    text: 'Mail area cannot be empty!'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'error',
                title: 'Informations can not updated!',
                text: 'Process cancelled!'
            });
        }
    });
});

//for do not recommend


//etc

// Vote -- End