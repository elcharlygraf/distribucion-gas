<?php
/**
 * Created by PhpStorm.
 * User: User
 * Date: 19/07/2015
 * Time: 10:59 AM
 */

class IntranetController extends BaseController{

    public function InitializeCalendar(){
        return View::make('intranet.calendar.calendar');
    }

    public function InitializeParticipantes(){
        return View::make('intranet.participantes.participantes');
    }

    public function ReprogramarParticipantes(){
        return View::make('intranet.reprogramacion.reprogramacion');
    }

    public function ObtenerParticipantesPorFechaYDia(){
        $participante = new Participante;
        //obtenemos los parametros
        $fecha = $_GET['fecha'];
        $dia = $_GET['dia'];
        //llamamos a la funcion
        $participantesPorTurno = $participante->obtenerPorFechaAgrupadosEnTurnos($fecha, $dia);

        return Response::json(array(
            'result' =>  $participantesPorTurno
        ), 200
        )->setCallback(Input::get('callback'));
    }

    public function ObtenerParticipantesPorFechaYTurno(){
        $participante = new Participante;
        //obtenemos los parametros
        $fecha = $_GET['fecha'];
        $turno = $_GET['turno'];
        $searchText = $_GET['searchText'];

        $participantesPorTurno = null;
        //si existen los valores
        if($fecha && $turno && (strlen($searchText) == 0)){
            $participantesPorTurno = $participante->obtenerParticipantesPorFechayTurno($fecha, $turno);
        }
        else if ($fecha && $turno && (strlen($searchText) > 0)){
            $participantesPorTurno = $participante->obtenerParticipantesPorFechayTurnoYSearchText($fecha, $turno, $searchText);
        }

        return Response::json(array(
            'result' =>  $participantesPorTurno
        ), 200
        )->setCallback(Input::get('callback'));
    }

    public function ObtenerDetalleOperacionPorRegistro(){

        $detOperacionId  = $_GET['detOperacionId'];

        $detalleOperacionObj = new DetalleNroOperacion;
        $detalleNroOperacionInfo = $detalleOperacionObj->obtenerDetalleOperacionPorId($detOperacionId);

        $participante = new Participante;
        $nroParticipantes =  $participante->obtenerNumeroDeParticipantesPorDetalleOperacionId($detOperacionId);

        $detalleOperacion =  new stdClass;
        $detalleOperacion->fecha = $detalleNroOperacionInfo->detop_fecha;
        $detalleOperacion->horas = $detalleNroOperacionInfo->detop_horas;
        $detalleOperacion->minutos = $detalleNroOperacionInfo->detop_minutos;
        $detalleOperacion->apm = $detalleNroOperacionInfo->detop_apm;
        $detalleOperacion->monto = $detalleNroOperacionInfo->detop_monto;
        $detalleOperacion->cantidadParticipantes = $nroParticipantes;
        $detalleOperacion->tipoPago = $detalleNroOperacionInfo->detop_tipoPago;

        return Response::json(array(
            'result' =>  $detalleOperacion
        ), 200
        )->setCallback(Input::get('callback'));
    }

    public function GuardarDetalleOperacionPorRegistro(){
        $detalle  = $_GET['detalle'];
        $newDetalleOperacion = new DetalleNroOperacion();

        $newDetalleOperacion->guardarDetalleNroOperacion($detalle["detOperacionId"],$detalle['nroOperacion'],$detalle['monto'],$detalle['fecha'],
                                                        $detalle['horas'],$detalle['minutos'],$detalle['apm'],
                                                        $detalle['tipoPago']);

        return Response::json(array(
            'result' =>  true
        ), 200
        )->setCallback(Input::get('callback'));
    }

    public function ActualizarParticipantes(){
        $participante = new Participante;
        $registro = new Registro;

        $participantesArray = $_GET['participantes'];

        foreach($participantesArray as $par){
            $participante->actualizarParticipante($par);
            $registro->actualizarNroOperacion($par["registroId"],$par["nroOperacion"]);
        }

        return Response::json(array(
            'result' =>  true
        ), 200
        )->setCallback(Input::get('callback'));
    }

    public function AgregarTurnoManual(){
        $nuevoTurno = $_GET['turno'];

        $turnoObj =  new Turno();
        $turnoObj->guardarTurno($nuevoTurno["dia"],$nuevoTurno["hora_inicio"],$nuevoTurno["hora_fin"],$nuevoTurno["fecha_unica"]);

        return Response::json(array(
            'result' =>  true
        ), 200
        )->setCallback(Input::get('callback'));
    }

    public function RegistarParticipanteManual(){
        $participanteObj = new Participante;
        $participante = $_GET['participante'];

        $fecha = $participante["fecha"];
        $turnoId = $participante["turno"];

        //variable para almacenar resultado
        $validation = array();
        $resultado = true;


        if($participanteObj->puedeParticipanteRegistrarse($fecha, $turnoId, 1 , "M")){
            if($participante["tipoRegistro"] == "J"){
                /*registro de empresa*/
                $ruc = $participante['ruc'];
                $razonSocial = $participante['razonSocial'];

                $savedEmpresa = with(new Empresa)->registrarEmpresa($ruc, $razonSocial);

                /*registro de pagos*/
                $nroOperacion = $participante['nroOperacion'];
                $montoPago = $participante['monto'];

                $savedRegistro = with(new Registro)->inicializarRegistro($nroOperacion, $montoPago, "M"); //$archivo

                $savedGrupoRegistro = with(new GrupoRegistro)->registrarGrupo(DateTime::createFromFormat('Y-m-d', $fecha)->format('d/m/Y'), $turnoId);

                //GrupoRegistro - Operador
                $operadores = $participante['almacenes'];
                with(new GrupoRegistroOperadorRelacion)->registrarGrupoOperadorRelaction($operadores, $savedGrupoRegistro->greg_id);

                //RegistroPersonaJuridica
                with(new RegistroPersonaJuridica)->registrarPersonaJuridica($savedRegistro->reg_id, $savedGrupoRegistro->greg_id);

                //GrupoRegistro - Participante
                $participantes = $participante['participante'];
                with(new GrupoRegistroParticipanteRelacion)->registrarGrupoParticipanteRelaction($participantes, $savedGrupoRegistro->greg_id, $savedEmpresa->emp_id);
            }
            else{
                /*registro de pagos*/
                $nroOperacion = $participante['nroOperacion'];
                $montoPago = $participante['monto'];

                $savedRegistro = with(new Registro)->inicializarRegistro($nroOperacion, $montoPago, "M");//$archivo

                /*registor del participante*/
                //creamos al participante
                $participanteRaw = array (
                    "dni" =>   $participante['dni'],
                    "nombres" =>  $participante['nombres'],
                    "ape_paterno" => $participante['ape_paterno'],
                    "ape_materno" => $participante['ape_materno']
                );
                //lo guardamos
                $savedParticipante = with(new Participante)->guardar($participanteRaw);

                $registroPersonaNatural = with(new RegistroPersonaNatural)->registrarPersonaNatural($savedRegistro->reg_id,$savedParticipante->pa_id, DateTime::createFromFormat('Y-m-d', $fecha)->format('d/m/Y') ,$turnoId,null);

                /*registro de los operadores*/
                $operadores = $participante['almacenes'];

                with(new RegistroPersonaNaturalOperadorRelacion)->registrarNaturalOperadorRelaction($operadores, $registroPersonaNatural->regnat_id);
            }
        }
        else{
            $turno = with(new Turno)->obtenerTurnoPorIdTodos($turnoId);

            $resultado = false;
            $limite =  new stdClass();
            $limite->fecha = DateTime::createFromFormat('Y-m-d', $fecha)->format('d/m/Y');
            $limite->turno = $turno;
            array_push($validation,$limite);
        }

        return Response::json(array(
            'resultado' =>  $resultado,
            'validation' => $validation
        ), 200
        )->setCallback(Input::get('callback'));

    }

    public function GenerarFichaExcel($turno, $fecha){
        $participante = new Participante;
        $participantesPorTurno = $participante->obtenerParticipantesPorFechayTurno($fecha, $turno);
        $fechaOriginal = DateTime::createFromFormat('Y-m-d', $fecha);
        $fechaFormat = $fechaOriginal->format('d/m/Y');
        Log::info($participantesPorTurno);
        Excel::create("RegistroAsistencia", function($excel) use($fechaFormat, $participantesPorTurno){
            $excel->sheet('Sheetname', function($sheet) use($fechaFormat, $participantesPorTurno){
                $sheet->loadView('excel.registroAsistencia')->with('fecha', $fechaFormat)->with('participantes', $participantesPorTurno);
                $sheet->cells('A1:I1', function($cells) {
                    // manipulate the range of cells
                    // Set font size
                    $cells->setFontSize(18);
                    $cells->setFontWeight('bold');
                });
            });
        })->export('xlsx');
    }

    public function ObtenerParticipantesAReprogramar(){
        $participante = new Participante;
        $participantesAReprogramar = null;

        $searchText = $_GET['searchText'];
        //llamamos a la funcion
        if($searchText && strlen($searchText) > 0){
            $participantesAReprogramar = $participante->obtenerParticipantesAReprogramarBySearchtext($searchText);
        }
        else{
            $participantesAReprogramar = $participante->obtenerParticipantesAReprogramar();
        }


        return Response::json(array(
            'result' =>  $participantesAReprogramar
        ), 200
        )->setCallback(Input::get('callback'));
    }
}