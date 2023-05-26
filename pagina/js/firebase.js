window.addEventListener("load", iniciarFirebase());

//Vars Firebase
var firebase_DB = firebase.database();
var firebase_Storage = firebase.storage();
var user = null;

// vars for Pay
var nameVenta = "";

// Init Firebase
function iniciarFirebase(){
    const firebaseConfig = {
        apiKey: "AIzaSyCZd3bMpSacnJ7jXvz0ctToCTetsTGcCG8",
        authDomain: "teocompu-37410.firebaseapp.com",
        databaseURL: "https://teocompu-37410-default-rtdb.firebaseio.com",
        projectId: "teocompu-37410",
        storageBucket: "teocompu-37410.appspot.com",
        messagingSenderId: "916704669530",
        appId: "1:916704669530:web:b1ec13ffb54e5b4f7d0d63",
        measurementId: "G-KRMVYV2SL9"
      };
    
      // Initialize Firebase
      const fireApp = firebase.initializeApp(firebaseConfig);
      //const analytics = getAnalytics(app);
}





async function getDataWithoutUpdating(DB_Reference){
    var dataToReturn = null;
     await firebase.database().ref(DB_Reference).once('value').then(async (snapshot) => {
        dataToReturn = snapshot.val();   
        console.log(snapshot.val());
    });
    return dataToReturn;
}



function generateStatus(data){
    let status = [
        "Saliendo de almacen",
        "Retenido en aduanas",
        "Bloqueado en Sinaloa por Narco Bloqueo",
        "Bloqueado en Michoacan por Narco Bloqueo",
        "Bloqueado en Rusa por guerra",
        "Entregado",
        "Entregando",
        "Esperando en paqueteria"
    ]

    let min = Math.ceil(0);
    let max = Math.floor(status.length);
    let res = Math.floor(Math.random() * (max - min + 1) + min);
    let index = "";
    let bandera = false;
    if(data==""){
        bandera = false;
    }
    data = status[res];
    
    if(bandera && status[5] == data ){
        index = status[0];
    }else if(data==status[0] && bandera==false){
        index = status[7];
    }else if(data==status[7] && bandera==false){
        index = status[6];
    }else if(data==status[6] && bandera==false){
        index = status[5];
    }else if(data==status[5] && bandera==false){
        index = status[5];
    }else{
        index = status[res];
    }

    return index;
}