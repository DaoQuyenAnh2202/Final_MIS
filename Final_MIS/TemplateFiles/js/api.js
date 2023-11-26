$('.AddToCart').off('click').on('click', function (e) {
    e.preventDefault();
    var btn = $(this);
    var id = btn.data('id');
    var quantity = 1;
    var data = {
        productID: id,
        quantity: quantity
    }
    $.ajax({
        url: "/api/cart",
        dataType: "json",
        method: "POST",
        data: JSON.stringify(data),
        success: (rs) => {
            alert("Thêm vào giỏ hàng thành công!");
        },
        error: (rs) => {
            if (rs.status == 401) {
                alert('Vui lòng đăng nhập trước khi thêm sản phẩm vào giỏ hàng!');
                //document.location.href = "/login";
            } else
                if (rs.status == 200)
                    alert("Thêm vào giỏ hàng thành công!");
        }
    });
});
$('.del-cart').off('click').on('click', function (e) {
    e.preventDefault();
    var btn = $(this);
    var id = btn.data('id');
    var quantity = 1;
    var data = {
        productID: id,
        quantity: quantity
    }
    $.ajax({
        url: "/api/cart/delete",
        dataType: "json",
        method: "POST",
        data: JSON.stringify(data),
        success: (rs) => {
            alert("Xóa giỏ hàng thành công!");
        },
        error: (rs) => {
            if (rs.status == 401) {
                alert('Vui lòng đăng nhập trước khi thêm sản phẩm vào giỏ hàng!');
                //document.location.href = "/login";
            } else
                if (rs.status == 200) {
                    alert("Xóa giỏ hàng thành công!");
                    document.location.href = "/User/Cart.aspx";
                }
        }
    });
});
$('.quantity-input').off('change').on('change', function (e) {
    e.preventDefault();
    var btn = $(this);
    var id = btn.data('id');
    var data = {
        productID: id,
        quantity: btn.val()
    }
    $.ajax({
        url: "/api/cart/update",
        dataType: "json",
        method: "POST",
        data: JSON.stringify(data),
        success: (rs) => {
            alert("Cập nhập giỏ hàng thành công!");
        },
        error: (rs) => {
            if (rs.status == 401) {
                alert('Vui lòng đăng nhập trước khi thêm sản phẩm vào giỏ hàng!');
                //document.location.href = "/login";
            } else
                if (rs.status == 200) {
                    alert("Cập nhập giỏ hàng thành công!");
                    document.location.href = "/User/Cart.aspx";
                }
        }
    });
});
$('#checkout').off('click').on('click', function (e) {
    e.preventDefault();
    $.ajax({
        url: "/api/checkout",
        dataType: "json",
        method: "POST",
        success: (rs) => {
            alert("Thanh toán thành công!");
        },
        error: (rs) => {
            if (rs.status == 401) {
                alert('Vui lòng đăng nhập trước khi thanh toán!');
                document.location.href = "/User/Login.aspx";
            } else
                if (rs.status == 200) {
                    alert("Thanh toán thành công!");
                    document.location.href = "/User/Cart.aspx";
                }
        }
    });
});