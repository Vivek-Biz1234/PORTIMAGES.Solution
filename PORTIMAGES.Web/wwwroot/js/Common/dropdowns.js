function bindDropdown(key, ddlSelector, parentId = null, selectedValue = null,atZeroIndex=null) {
    let url = `/Admin/Common/GetDropdown?key=${key}`;

    if (parentId !== null && parentId !== undefined) {
        url += `&parentId=${parentId}`;
    }

    $.get(url, function (res) {
        let html;
        if (res.status !== 1) {
            console.warn(res.message);
            ShowToast("warning", "Something went wrong", res.message);
            return;
        }        
        if (atZeroIndex === 0) {
            html = `<option value="0">Select</option>`;
        } else {
            html = `<option value="-1">Select</option>`;
        }

        $.each(res.data, function (i, item) { 
            let selected = selectedValue == item.id ? "selected" : "";
            html += `<option value="${item.id}" ${selected}>${item.name}</option>`;
        });

        $(ddlSelector).html(html);
    });
}
