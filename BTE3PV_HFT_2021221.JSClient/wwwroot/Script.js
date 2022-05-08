let Authors = [];
let connection = null;
let authorIdUpdate = -1;


getdata();
setupSignalR();

async function getdata() {
    await fetch('http://localhost:4854/Author')
        .then(x => x.json())
        .then(y => {
            Authors = y;
            display();
        });

}


function display() {
    document.getElementById('results').innerHTML = "";
    Authors.forEach(t => {
        document.getElementById('results').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" +
        t.authoreName + "</td><td>" +
        t.birthYear + "</td><td>" +
        t.specialization + "</td><td>" +
        t.birthcountry + "</td><td>"+
        t.writingLanguage + "</td><td>" +
        `<button type="button" onclick="remove(${t.id})">Delete</button>` +
        `<button type="button" onclick="showUpdate(${t.id})">Update</button>`        
            +"</td></tr>";
      });

}
function remove(id) {
    fetch('http://localhost:4854/Author/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
    
}
function setupSignalR()
{
     connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:4854/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AuthorCreated", (user, message) => {
        getdata();
    });

    connection.on("AuthorDeleted", (user, message) => {
        getdata();
    });
    connection.onclose(async () => {
        await start();
    });
    start();

}
    async function start() {
        try {
            await connection.start();
            console.log("SignalR Connected.");
        } catch (err) {
            console.log(err);
            setTimeout(start, 5000);
        }
};
function showUpdate(id) {
    document.getElementById('nameU').value = Authors.find(t => t['id'] == id)['authoreName']
    document.getElementById('birthU').value = Authors.find(t => t['id'] == id)['birthYear']
    document.getElementById('specU').value = Authors.find(t => t['id'] == id)['specialization']
    document.getElementById('countryU').value = Authors.find(t => t['id'] == id)['birthcountry']
    document.getElementById('languageU').value = Authors.find(t => t['id'] == id)['writingLanguage']
    document.getElementById('Updateformdiv').style.display = 'flex'
    authorIdUpdate = id;

}
function update() {
    document.getElementById('Updateformdiv').style.display = 'none'
    let aname = document.getElementById('nameU').value;
    let abirth = document.getElementById('birthU').value;
    let aspec = document.getElementById('specU').value;
    let acountry = document.getElementById('countryU').value;
    let alang = document.getElementById('languageU').value;
    fetch('http://localhost:4854/Author', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                id: authorIdUpdate,
                authoreName: aname,
                birthYear: abirth,
                specialization: aspec,
                birthcountry: acountry,
                writingLanguage: alang
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

}





function create() {
    let aname = document.getElementById('name').value;
    let abirth = document.getElementById('birth').value;
    let aspec = document.getElementById('spec').value;
    let acountry = document.getElementById('country').value;
    let alang = document.getElementById('language').value;
    fetch('http://localhost:4854/Author', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                authoreName: aname,
                birthYear: abirth,
                specialization: aspec,
                birthcountry: acountry,
                writingLanguage: alang
            }),
        })
    .then(response => response)
    .then(data => {
        console.log('Success:', data);
        getdata();
    })
    .catch((error) => {
        console.error('Error:', error);
    });
    
}