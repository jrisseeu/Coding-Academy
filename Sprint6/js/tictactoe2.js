
function handleCellClick() {

    alert("here in handleCellClick");

    //var clickedCell = clickedCellEvent.target;
    var clickedCellIndex = parseInt(clickedCell.getAttribute('index'));
    alert(clickedCellIndex);


}



document.querySelectorAll('.cell').forEach(cell => cell.addEventListener('click', handleCellClick));
//document.querySelector('.game--restart').addEventListener('click', handleRestartGame);
