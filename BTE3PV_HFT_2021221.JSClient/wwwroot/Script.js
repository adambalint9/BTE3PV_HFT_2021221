let Authors = [];
let coonection = null;
getdata();

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
        `<button type="button" onclick="remove(${t.id})">Delete</button>`


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
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:4854/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AuthorCreated", (user, message) => {
        console.log(user);
        console.log(message);
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