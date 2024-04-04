import { useEffect, useState } from 'react';
import Container from 'react-bootstrap/Container';
import PredstavaService from '../../services/PredstavaService';
import { Table } from 'react-bootstrap';
import { Link, Routes } from 'react-router-dom';
import { RoutesNames } from '../../constants'


export default function Predstave(){
    const [predstave, setPredstave] = useState();


    async function dohvatiPredstave(){
        await PredstavaService.get()
        .then((odg)=>{
            setPredstave(odg);
        })
        .catch((e)=>{
            console.log(e);
        });
    }

    useEffect(()=>{
        dohvatiPredstave();
    },[]);

    
    
    
    return(
        <>
           <Container>
           <Link to={RoutesNames.PREDSTAVA_NOVA} >Dodaj</Link>
            
            <Table striped bordered hover responsive>
                    <thead>
                        <tr>
                            <th>Naziv</th>
                            <th>Datum</th>
                            <th>Cijena</th>
                            
                        </tr>
                    </thead>
                    <tbody>
                        {predstave && predstave.map((predstava,index)=>(
                            <tr key={index}>
                                <td>{predstava.naziv}</td>
                                <td>{predstava.datum}</td>
                                <td>{predstava.cijena}</td>
                                
                            </tr>
                        ))}
                    </tbody>
            </Table>
           </Container>
        </>
    );
}