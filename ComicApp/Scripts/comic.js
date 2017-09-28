function getComicDetails() {
    var val = $("#updateComic #ddlComics").val();
    if (val != "") {
        var url = "http://localhost:50963/api/comicbook/" + val;
        
        $.ajax({
            url: url,
            type: "GET",
            dataType: "json",
            crossDomain: true,
            success: function (data) {
                $("#updateComic #id").val(data["Id"]);
                $("#updateComic #name").val(data["Name"]);
                $("#updateComic #desc").val(data["Description"]);
                $("#updateComic #issue").val(data["IssueNumber"]);
            }
        })

    }
}