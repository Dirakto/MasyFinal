var url = 'http://localhost:5000/Home/';

var skill = 
`<div>
    <label for="?">Nazwa:</label><input name="?" value="[Nazwa umiejetnosci]"/>
</div>
<div>
    <label for="?">Opis:</label><input type="textarea" name="?" value="[Opis]"/>
</div>
<div>
    <label for="?">Punkty obrażeń:</label><input name="?" value="[x]"/>
</div>
<div>
    <label for="?">Punkty leczenia:</label><input name="?" value="[x]"/>
</div>
<div>
    <label for="?">Punkty wytrzymałości:</label><input name="?" value="[x]"/>
</div>
<div>
    <label for="?">Klawisz:</label>
    <select class="special">
        <option value="Q">Q</option>
        <option value="R">R</option>
    </select>
</div>`;

// Adding Skill fieldsets
var button = document.getElementById('skillButton');
var zapisz = document.getElementById('zapisz');
var count = 1;

function addSkill(){
    if(count < 6){
        var el = document.createElement('fieldset');
        el.classList.add('skill')
        button.parentNode.insertBefore(el, button);
        el.innerHTML = skill;
        count++;
    }
    if(count == 4)
        zapisz.disabled = false;

    if(count == 6)
        button.classList.add('invisible');
}
button.onclick = addSkill;


// State changing
var stanButtons = document.querySelectorAll(".stanButton");
for(var i = 0; i < stanButtons.length; i++){
    stanButtons[i].addEventListener("click", function(event){
        event.stopPropagation();
        event.preventDefault();
        var _this = this;
        var tmp = this.previousElementSibling.previousElementSibling;
        ajaxRequest('GET', url+'ChangeStan?name='+tmp.textContent, function(xhr){
                _this.firstChild.innerHTML = tmp.nextElementSibling.textContent == 'Gotowy'? 'Dostepny' : tmp.nextElementSibling.textContent;
                tmp.nextElementSibling.innerHTML = xhr.responseText.substring(1, xhr.responseText.length-1);
            }, null);

        // ajaxRequest('POST', 'http://localhost:5000/Home/ChangeStan', function(xhr){
        //     tmp.innerHTML = xhr.responseText;
        // }, JSON.stringify({data:tmp.textContent}));
    });
}

// AJAX
function ajaxRequest(method, url, fun, msg){
    var xhr = new XMLHttpRequest();
    xhr.open(method, url, true)

    xhr.setRequestHeader("Content-Type", "application/json");
    xhr.setRequestHeader("charset", "utf-8");
    

    xhr.onload = function(){
        if(xhr.readyState == 4){
            fun(xhr);
        }
    };
    xhr.send(msg);
}


var tr = document.getElementsByTagName("tr");
for(var i = 1; i<tr.length; i++){
    var name = tr[i].firstChild.nextElementSibling.textContent;

    console.log(name);
    function tmp(){
        console.log('2 '+name);
        ajaxRequest('GET', url+'GetBohater?name='+name, function(xhr){
            console.log(xhr.responseText);
        }, null);
    }

    tr[i].addEventListener("click", tmp);
}