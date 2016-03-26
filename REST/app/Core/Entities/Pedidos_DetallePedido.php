<?php
namespace App\Core\Entities;
use Illuminate\Database\Eloquent\Model;

class PedidosDetallePedido extends Model
{
    protected $table = 't_detallePedido';
    protected $primaryKey = 'idDetallePedido';
    protected $connection = 'bdpedidos';
}
