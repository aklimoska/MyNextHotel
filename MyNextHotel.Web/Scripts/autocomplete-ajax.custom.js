$("#txtKeywordCity").autocomplete({
    source: function (request, response) {
        $.ajax({
            url: '@Url.Action("GetSearchValue","Autocomplete")',
            dataType: "json",
            data: { search: $("#txtKeywordCity").val() },
            success: function (data) {
                response($.map(data, function (item) {
                    return { label: item.Name, value: item.Name };
                }));
            },
            error: function (xhr, status, error) {
                alert("Error");
            }
        });
    }
});
