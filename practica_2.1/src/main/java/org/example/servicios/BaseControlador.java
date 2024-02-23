package org.example.servicios;

import io.javalin.Javalin;
import org.example.controladores.Cabeza;

public abstract class BaseControlador {

    protected Javalin app;
    Cabeza cabeza = Cabeza.getInstance();

    public BaseControlador(Javalin app){
        this.app = app;
    }

    abstract public void aplicarRutas();
}
