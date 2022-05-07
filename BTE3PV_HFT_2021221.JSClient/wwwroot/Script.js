let Authors = [];

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
    Authors.forEach(t => {
        document.getElementById('results').innerHTML +=
            "<tr><td>" + t.id + "</td><td>" +
        t.authoreName + "</td><td>" +
        t.birthYear + "</td><td>" +
        t.specialization + "</td><td>" +
        t.birthcountry + "</td><td>"+
        t.writingLanguage +     "</td></tr>";
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
                birthcountry: country,
                writingLanguage: alang
            }),
        })
    .then(response => response)
    .then(data => {
        console.log('Success:', data);
    })
    .catch((error) => {
        console.error('Error:', error);
    });
    getdata();
}