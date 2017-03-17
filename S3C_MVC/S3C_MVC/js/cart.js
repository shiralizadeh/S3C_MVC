$(function () {
    var $btnAddCart = $('.btn-add-cart');

    $btnAddCart.click(function () {
        var $this = $(this);

        var data = {
            ProductID: $this.data('productid')
        };

        $.post('/Cart/AddToCart', data).then(function (result) {

            if ($('[data-productid="' + result.ID + '"]').length > 0)
                $('[data-productid="' + result.ID + '"]').closest('tr').remove();


            $('.cart-list tbody').append(`<tr class="product-item" data-price="` + result.Price + `" data-count="` + result.Count + `">
                            <td class="text-center">
                                <a href="product.html">
                                    <img class="img-thumbnail" width="60" title="کفش راحتی مردانه" alt="کفش راحتی مردانه" src="/uploads/` + result.Image + `">
                                </a>
                            </td>
                            <td class="text-left">
                                <a href="product.html">
                                    ` + result.Title + `
                                </a>
                            </td>
                            <td class="text-right">x ` + result.Count + `</td>
                            <td class="text-right">` + (result.Price * result.Count) + ` تومان</td>
                            <td class="text-center">
                                <button class="btn btn-danger btn-xs remove btn-remove-cart" data-productid="` + result.ID + `" title="حذف" onClick="" type="button"><i class="fa fa-times"></i></button>
                            </td>
                        </tr>`);

            setPrices();
        });
        //$.ajax({
        //    url: '/Cart/AddToCart',
        //    type: 'post',
        //    data: data
        //});

    });

    $('.cart-list').delegate('.btn-remove-cart', 'click', function (e) {
        var $this = $(this);

        var data = {
            ProductID: $this.data('productid')
        };

        $.post('/Cart/RemoveFromCart', data).then(function (result) {
            if (result == 'True') { }

            $this.closest('tr').fadeOut(800, function () {
                $this.remove();
            });

            setPrices();
        });

        e.preventDefault();
        e.stopPropagation();
    });

    console.log($('.btn-remove-cart'));

});

function setPrices() {
    $('.cart-count').text($('tr.product-item').length);

    var totalPrice = 0;
    $('tr.product-item').each(function () {
        var $this = $(this);

        totalPrice += parseInt($this.data('price')) * parseInt($this.data('count'));
    });

    $('.total-price').text(totalPrice + ' تومان');
    $('.tax-price').text((totalPrice * 0.09) + ' تومان');
    $('.topay-price').text((totalPrice + (totalPrice * 0.09)) + ' تومان');
}