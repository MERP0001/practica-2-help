package org.example.servicios;


import io.javalin.Javalin;
import io.javalin.rendering.JavalinRenderer;
import io.javalin.rendering.template.JavalinThymeleaf;
import org.example.controladores.Cabeza;
import org.example.entidades.Articulo;
import org.example.entidades.Comentario;
import org.example.entidades.Etiqueta;
import org.example.entidades.Usuario;

import java.util.*;


public class serviciosArticulos extends BaseControlador {
    Cabeza cabeza = Cabeza.getInstance();
    public  serviciosArticulos(Javalin app){
        super(app);
        buscarTemplates();
    }
    public void buscarTemplates(){
        JavalinRenderer.register(new JavalinThymeleaf(),".html");
    }


    @Override
    public void aplicarRutas() {
        List<Articulo> articulos = cabeza.listarArticulos();
        List<Etiqueta> etiquetas = cabeza.listarEtiquetas();

        app.before("/Blog", ctx -> {
            Usuario user = ctx.sessionAttribute("usuario");
            if(user != null){
                System.out.println(user.getNombre() + user.getUsername());
                ctx.attribute("usuario", user);
            }
            ctx.attribute("etiquetas",etiquetas);
            ctx.render("publico/Blog.html", Map.of("articulos", articulos));
        });
        app.before("/crear_articulo", ctx -> {
            Usuario user = ctx.sessionAttribute("usuario");
            ctx.attribute("usuario",user);
            Map<String, String> model = new HashMap<>();
            model.put("titulo", "Crear Articulo");
            ctx.render("/publico/Crear_articulo.html");
        });
        app.get("/crear_articulo", ctx -> {
            Map<String, String> model = new HashMap<>();
            model.put("titulo", "Crear Usuario");
            ctx.render("/publico/Crear_articulo.html");
        });
        app.post("/crear_articulo", ctx -> {
            String titulo = ctx.formParam("titulo");
            String cuerpo = ctx.formParam("cuerpo");
            String etiqueta = ctx.formParam("etiquetas");
            String[] dividos = etiqueta.split(",");
            Articulo temp = new Articulo(titulo,cuerpo,ctx.sessionAttribute("usuario"),new Date(),null,null);
            for (String eti : dividos){
                if(cabeza.find_Etiqueta(eti) == null){
                    cabeza.add_etiqueta(eti);
                }
                temp.add_etiqueta(cabeza.find_Etiqueta(eti));
                System.out.println("agregaste la siguiente etiqueta" +  cabeza.find_Etiqueta(eti).getEtiqueta());
            }
            cabeza.add_articulo(temp);
            ctx.redirect("/Blog");

        });



        app.before("/Crear_usuario", ctx -> {
            Map<String, String> model = new HashMap<>();
            model.put("titulo", "Crear Usuario (admin)");
            ctx.render("/publico/Crear_usuario.html");
        });
        app.get("/Crear_usuario", ctx -> {
            Map<String, String> model = new HashMap<>();
            model.put("titulo", "Crear Usuario (admin)");
            ctx.render("/publico/Crear_usuario.html");
        });
//        app.post("/Crear_usuario", ctx -> {
//            ctx.redirect("/Blog");
//        });
        app.get("/login", ctx -> {
            Map<String, String> model = new HashMap<>();
            model.put("titulo", "Log in");
            ctx.render("/publico/login.html");
        });
        // Ruta para manejar el inicio de sesión (podría ser una solicitud POST)
        app.post("/login", ctx -> {
            // Lógica de manejo de inicio de sesión...
            // Aquí rediriges a la ruta adecuada para manejar el inicio de sesión
            ctx.redirect("/login");
        });
        app.before("/ver_articulo/{id}", ctx -> {
            long id = Long.parseLong(ctx.pathParam("id"));
            Articulo articulo = cabeza.find_Articulo(id);
//            System.out.println(articulo.getTitulo() + "  SE LOGRO");
            ctx.attribute("articulo", articulo);
            ctx.attribute("usuario",ctx.sessionAttribute("usuario"));
            ctx.render("/publico/Ver_articulo.html");
        });
        app.get("/ver_articulo/{id}", ctx -> {
            Map<String, String> model = new HashMap<>();
            model.put("titulo", "Ver Usuario");
            ctx.render("/publico/Ver_articulo.html");
        });
        app.post("/ver_articulo_back", ctx -> {

            ctx.redirect("/Blog");

        });
        app.before("/editar_articulo/{id}", ctx -> {
            long id = Long.parseLong(ctx.pathParam("id"));
            Articulo articulo = cabeza.find_Articulo(id);
            System.out.println(articulo.getTitulo() + "  SE ESTA MODIFICANDO");
            ctx.attribute("articulo", articulo);
            ctx.attribute("usuario",ctx.sessionAttribute("usuario"));
            Map<String, String> model = new HashMap<>();
            model.put("titulo", "Modificar Articulo");
            ctx.render("/publico/editar_articulo.html");
        });
        app.get("/editar_articulo/{id}", ctx -> {
            Map<String, String> model = new HashMap<>();
            model.put("titulo", "Modificar Articulo");
            ctx.render("/publico/editar_articulo.html");
        });
        app.post("/editar_articulo/{id}", ctx -> {
            String titulo = ctx.formParam("titulo");
            String cuerpo = ctx.formParam("cuerpo");
            String etiqueta = ctx.formParam("etiquetas");
            String[] dividos = etiqueta.split(",");
            Articulo idtaker = ctx.attribute("articulo");
            Articulo temp = new Articulo(titulo,cuerpo,ctx.sessionAttribute("usuario"),new Date(),null,null);
            for (String eti : dividos){
                cabeza.add_etiqueta(eti);
                temp.add_etiqueta(cabeza.find_Etiqueta(eti));
                //System.out.println("agregaste la siguiente etiqueta" +  cabeza.find_Etiqueta(eti).getEtiqueta());
            }
            System.out.println(temp.getId());
            long id = Long.parseLong(ctx.pathParam("id"));
            cabeza.modArticulo(temp,id);
            ctx.redirect("/Blog");

        });
        app.get("/eliminar_articulo/{id}", ctx -> {
            long id = Long.parseLong(ctx.pathParam("id"));
            System.out.println("SE ESTA ELIMINO");
            cabeza.deleteArticulo(id);
            ctx.redirect("/Blog");

        });
        app.get("/Comentario/{id}", ctx -> {
            long id = Long.parseLong(ctx.pathParam("id"));
            System.out.println("SE HIZO COMENTARIO");
            ctx.redirect("/Blog");
        });
        app.post("/ver_articulo/{id}", ctx -> {
            long id = Long.parseLong(ctx.pathParam("id"));
            Articulo temp = cabeza.find_Articulo(id);
            System.out.println(ctx.formParam("Comentario"));
            Comentario comentario = new Comentario(ctx.formParam("Comentario"),ctx.sessionAttribute("usuario"),temp);
            temp.add_comentario(comentario);
            cabeza.add_comentario(comentario);
            System.out.println("SE HIZO COMENTARIO");

            ctx.redirect("/Blog");

        });

    }

}
