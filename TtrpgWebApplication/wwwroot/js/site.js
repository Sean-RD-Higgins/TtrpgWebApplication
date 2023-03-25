// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function refreshAllStats() {
    let statNodeList = $(".stat-value");
    for (let statNode of statNodeList) {
        statNode.click();
    }
}

function roll(maxRoll) {
    return Math.floor(Math.random() * (maxRoll + 1));
}

function addToStat(targetFieldTagName, sourceFieldName, addedValue) {
    let nodeSelector = "#" + targetFieldTagName;
    let node = $(nodeSelector);
    let sourceNodeSelector = "#" + sourceFieldName;
    let sourceNode = $(sourceNodeSelector);
    node.val(parseInt(sourceNode.val()) + addedValue);
}

function addStat(fieldTagName, addedValue) {
    let nodeSelector = "#" + fieldTagName;
    let node = $(nodeSelector);
    if (node.val() == "") {
        node.val(0);
    }
    node.val(parseInt(node.val()) + addedValue);
}

function subtractStat(fieldTagName, addedValue) {
    let nodeSelector = "#" + fieldTagName;
    let node = $(nodeSelector);
    node.val(parseInt(node.val()) - addedValue);
}

function setStat(fieldTagName, setValue) {
    let nodeSelector = "#" + fieldTagName;
    let node = $(nodeSelector);
    node.val(setValue);
}

function getStat(fieldTagName) {
    let nodeSelector = "#" + fieldTagName;
    let node = $(nodeSelector);
    return node.val();
}

refreshAllStats();
refreshAllStats();