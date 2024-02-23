package org.example.servicios;

import io.javalin.Javalin;
import io.javalin.rendering.JavalinRenderer;
import io.javalin.rendering.template.JavalinThymeleaf;
import org.example.entidades.Usuario;

import java.util.HashMap;
import java.util.Map;

public class serviciosUsuarios  extends BaseControlador{
    public  serviciosUsuarios(Javalin app){
        super(app);
        buscarTemplates();
    }


    public void buscarTemplates(){
        JavalinRenderer.register(new JavalinThymeleaf(),".html");
    }
    @Override
    public void aplicarRutas() {


        Javalin javalin = app.before("/login", ctx -> {
            Map<String, String> model = new HashMap<>();
            model.put("titulo", "Log in");
            ctx.render("/publico/login.html", model);
//            System.out.println("si ves estos cmacate");
        });
        app.post("/Blog", ctx -> {
            String user = ctx.formParam("usuario");
            String contrasena = ctx.formParam("password");

            Usuario usuario = new Usuario(user, "", contrasena, false, true);

            // Condición para validar el usuario y la contraseña
            if (cabeza.usuarioExiste(usuario.getUsername()) && cabeza.validPassword(contrasena, usuario)) {
                ctx.sessionAttribute("usuario", cabeza.find_usuario(usuario.getUsername()));
                ctx.redirect("/Blog"); // Redirigir al blog si la autenticación es exitosa
            } else {
                // Si la autenticación falla, renderizar nuevamente el formulario de inicio de sesión con un mensaje de error
                Map<String, Object> model = new HashMap<>();
                model.put("error", "Usuario o contraseña incorrectos");
                ctx.render("/publico/login.html", model);
            }
        });
//==================================================================================================
//        app.before("/Crear_usuario", ctx -> {
//            Map<String, String> model = new HashMap<>();
//            model.put("titulo", "Crear usario (admin)");
//            ctx.render("/publico/Crear_usuario.html", model);
//            //System.out.println("si ves estos corona");
//        });
        app.post("/Crear_usuario", ctx->{
            String nombre = ctx.formParam("Nombre");
            String user = ctx.formParam("usuario");
            String contrasena = ctx.formParam("password");
            Usuario usuario = new Usuario(user, nombre, contrasena, false, true);
            if(cabeza.usuarioExiste(usuario.getUsername())){
                System.out.println("si ves estos se creo el usuario");
                ctx.sessionAttribute("usuario", cabeza.find_usuario(usuario.getUsername()));
                cabeza.add_user(usuario);
                ctx.render("/publico/Blog.html");
            }
            System.out.println("si ves estos se creo el usuario");
            ctx.sessionAttribute("usuario", cabeza.find_usuario(usuario.getUsername()));
            cabeza.add_user(usuario);
            ctx.render("/publico/Blog.html");
        });
//        app.get("/Crear_usuario", ctx -> {
//            // Verificar si el usuario está autenticado antes de renderizar la página del blog
//                ctx.render("/publico/Blog.html");
//
//        });
//=====================================================================================================
        app.get("/Blog", ctx -> {
            // Verificar si el usuario está autenticado antes de renderizar la página del blog
            Usuario usuario = ctx.sessionAttribute("usuario");
            if (usuario != null) {
                ctx.render("/publico/Blog.html");
            } else {
                // Si el usuario no está autenticado, redirigir al formulario de inicio de sesión
                ctx.redirect("/login");
            }
        });

    }
}
