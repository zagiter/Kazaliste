import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RoutesNames } from "../../constants";
import PredstavaService from "../../services/PredstavaService";
import { useEffect, useState } from "react";


export default function PredstavePromjena(){
    const navigate = useNavigate();
    const routeParams = useParams();
    const [predstava, setPredstava] = useState({});

   async function dohvatiPredstava(){
        const o = await PredstavaService.getBySifra(routeParams.sifra);
        if(o.greska){
            console.log(o.poruka);
            alert('Pogledaj konzolu');
            return;
        }
        setPredstava(o.poruka);
   }

   async function promjeni(predstava){
    const odgovor = await PredstavaService.put(routeParams.sifra,predstava);
    if (odgovor.greska){
        console.log(odgovor.poruka);
        alert('Pogledaj konzolu');
        return;
    }
    navigate(RoutesNames.PREDSTAVA_PREGLED);
}

   useEffect(()=>{
    dohvatiPredstava();
   },[]);

    function obradiSubmit(e){ // e predstavlja event
        e.preventDefault();
      

        const podaci = new FormData(e.target);

        const predstava = {
            naziv: podaci.get('naziv'),  
            datum: podaci.get('datum'), 
            cijena: podaci.get('cijena'),              
        };
      
        promjeni(predstava);

    }

    return (

        <Container>
            <Form onSubmit={obradiSubmit}>

                <Form.Group controlId="naziv">
                    <Form.Label>Naziv</Form.Label>
                    <Form.Control 
                    type="text" 
                    name="naziv" 
                    defaultValue={predstava.naziv}
                    required />
                </Form.Group>

                <Form.Group controlId="datum">
                    <Form.Label>Datum</Form.Label>
                    <Form.Control 
                    type="text" 
                    name="datum"
                    defaultValue={predstava.datum}
                    />
                </Form.Group>

                <Form.Group controlId="cijena">
                    <Form.Label>Cijena</Form.Label>
                    <Form.Control 
                    type="text" 
                    name="cijena" 
                    defaultValue={predstava.cijena} 
                    />
                </Form.Group>


                <hr />
                <Row>
                    <Col>
                        <Link className="btn btn-danger siroko" to={RoutesNames.PREDSTAVA_PREGLED}>
                            Odustani
                        </Link>
                    </Col>
                    <Col>
                        <Button className="siroko" variant="primary" type="submit">
                            Promijeni
                        </Button>
                    </Col>
                </Row>

            </Form>
        </Container>

    );
}