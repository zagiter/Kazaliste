import { useEffect, useState } from 'react';
import Container from 'react-bootstrap/Container';
import PredstavaService from '../../services/PredstavaService';
import { Button, Table } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import { RoutesNames } from '../../constants'


export default function Predstave(){
    const [predstave, setPredstave] = useState();
    const navigate = useNavigate();

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


    async function obrisiAsync(sifra){
        const odgovor = await PredstavaService._delete(sifra);
        if (odgovor.greska){
            console.log(odgovor.poruka);
            alert('Pogledaj konzolu');
            return;
        }
        dohvatiPredstave();
    }
    
    function obrisi(sifra){
        obrisiAsync(sifra);
    }
    
    return(
        <>
           <Container>
            <Link to={RoutesNames.PREDSTAVA_NOVA} > Dodaj </Link>
            <Table striped bordered hover responsive>
                    <thead>
                        <tr>
                            <th>Naziv</th>
                            <th>Datum</th>
                            <th>Cijena</th>
                            <th>Akcija</th>
                            
                       </tr>
                    </thead>
                    <tbody>
                        {predstave && predstave.map((predstava,index)=>(
                            <tr key={index}>
                                <td>{predstava.naziv}</td>
                                <td>{predstava.datum}</td>
                                <td>{predstava.cijena}</td>
                                
                                <td>
                                    <Button 
                                    onClick={()=>obrisi(predstava.sifra)}
                                    variant='danger'
                                    >
                                        Obriši
                                    </Button>
                                        {/* kosi jednostruki navodnici `` su AltGR (desni) + 7 */}
                                    <Button 
                                    onClick={()=>{navigate(`/smjerovi/${smjer.sifra}`)}}
                                    >
                                        Promjeni
                                    </Button>
                                </td>                                
                            </tr>
                        ))}
                    </tbody>
            </Table>
           </Container>
        </>
    );
}