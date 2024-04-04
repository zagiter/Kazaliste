
import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import PredstavaService from "../../services/PredstavaService";


export default function PredstaveDodaj(){
    const navigate = useNavigate();

    async function dodaj(predstava){
        const odgovor = await PredstavaService.post(predstava);
        if (odgovor.greska){
            console.log(odgovor.poruka)
            alert('Pogledaj konzolu');
            return;
        }
        navigate(RoutesNames.PREDSTAVA_PREGLED);
    }
        
    function obradiSubmit(e){  
        e.preventDefault();
        //alert('Dodajem predstavu');

        const podaci = new FormData(e.target);

        const predstava = {
            naziv: podaci.get('naziv'),  
            //datum: parseDateTime(podaci.get('datum')),
            //datum: podaci.get('datum'),
            cijena: parseFloat(podaci.get('cijena'))
            
        };

        //console.log(predstava);
        dodaj(predstava);
        }


    return (

        <Container>
            <Form onSubmit={obradiSubmit}>
            
                <Form.Group controlId="naziv">
                    <Form.Label>Naziv</Form.Label>
                    <Form.Control type="text" name="naziv" required />
                </Form.Group>

                <Form.Group controlId="datum">
                    <Form.Label>Datum i vrijeme</Form.Label>
                    <Form.Control type="text" name="datum" />
                </Form.Group>

                <Form.Group controlId="cijena">
                    <Form.Label>Cijena</Form.Label>
                    <Form.Control type="text" name="cijena" />
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
                            Dodaj
                        </Button>
                                        
                    
                    </Col>
                
                </Row>
            </Form>
        
        </Container>
    );
}